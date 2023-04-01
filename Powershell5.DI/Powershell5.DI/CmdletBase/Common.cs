namespace UTMO.Powershell5.DI.CmdletBase
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Management.Automation;
  using System.Reflection;
  using System.Text.RegularExpressions;
  using UTMO.Powershell5.DI.DI;
  using UTMO.Powershell5.DI.Exceptions;

  public static class Common
  {
    private static List<Exception> Exceptions;

    public static void PerformFieldInjection<T>(this Cmdlet cmdlet) where T : Attribute, IShouldInject
    {
      Exceptions = new List<Exception>();

      var injectableProperties = cmdlet.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Where(
       p => p.CustomAttributes.Any(a => a.AttributeType == typeof(T))).ToList();

      if (injectableProperties.Any())
      {
        foreach (var property in injectableProperties)
        {
          try
          {
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string resolverName = property.GetCustomAttribute<T>().Name;
            var    targetType   = property.PropertyType;

            var instance = string.IsNullOrWhiteSpace(resolverName)
                             ? InternalContainer.Container.Value.Resolve(targetType)
                             : InternalContainer.Container.Value.Resolve(targetType, resolverName);

            property.SetValue(cmdlet, instance);
          }
          catch (ArgumentException ae)
          {
            var matcher = new Regex("Property (?<Accessor>.*) method not found.", RegexOptions.Compiled);

            if (matcher.IsMatch(ae.Message))
            {
              var acc = matcher.Match(ae.Message);
              var ex = new InjectablePropertyMissingSetterException(property.Name,
                                                                    acc.Groups["Accessor"].Value);
              Exceptions.Add(ex);
              continue;
            }

            Exceptions.Add(ae);
          }
          catch (Exception ex)
          {
            Exceptions.Add(ex);
          }
        }

        if (Exceptions.Any())
        {
          if (Exceptions.Count == 1)
          {
            throw Exceptions.First();
          }
          else
          {
            throw new AggregateException(Exceptions);
          }
        }
      }
    }
  }
}