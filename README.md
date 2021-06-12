# PowerShell5.DI
A library that enables Dependency Injection into PowerShell Cmdlets

Project Work Items (and coming soon builds) Can be found at: [Azure Dev Ops](https://dev.azure.com/utmo-public/PowerShell%20Infrastructure/)

# How to use

## Install Package

* UTMO.PowerShell5.DI.Unity

**IMPORTANT**: UTMO.PowerShell5.DI only contains the abstractions necessary for dependancy injection in powershell. Not any useable implementations.

## Create Your DI Container Class

``` c
public class MyDiContainer : PsUnityContainer
{
  public MyDiContainer()
  {
    this.Resolve<IContract,Implimentation>();
  }
}
```

## Create a Cmdlet

``` c
public class GetSomething : DiBasePsCmdlet
{
  [ShouldInject]
  private SomeService MyInjectedService { get; set; }
  
  protected override voide Process()
  {
    this.MyInjectedService.CallSomeMethod();
  }
}
```

OR

``` c
public class GetSomething : DiBaseCmdlet
{
  [ShouldInject]
  private SomeService MyInjectedService { get; set; }
  
  protected override voide Process()
  {
    this.MyInjectedService.CallSomeMethod();
  }
}
```
