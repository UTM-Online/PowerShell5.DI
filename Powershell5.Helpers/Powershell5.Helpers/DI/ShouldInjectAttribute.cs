namespace Powershell5.Helpers
{
    using System;

    public class ShouldInjectAttribute : Attribute
    {
        public string Name { get; set; }

        public ShouldInjectAttribute()
        {
        }

        public ShouldInjectAttribute(string name)
        {
            this.Name = name;
        }
    }
}