# Decorator
### Structural Design Pattern

![pattern structure](Images/Decorator-Structure.png)

###### Vehicle
~~~c#
public abstract class Vehicle
{
    protected Vehicle()
    {
    }

    public abstract void Display();
}
~~~

###### BaseCar
~~~c#
public class BaseCar : Vehicle
{
    public override void Display()
    {
        Console.WriteLine("Base package: added");
    }
}
~~~

###### Decorator
~~~c#
internal abstract class Decorator : Vehicle
{
    protected Decorator(Vehicle vehicle)
    {
        this.Vehicle = vehicle;
    }

    protected Vehicle Vehicle { get; set; }

    public override void Display()
    {
        this.Vehicle.Display();
    }
}
~~~

###### VehicleWithLightPackage
~~~c#
public class VehicleWithLightPackage : Decorator
{
    public VehicleWithLightPackage(Vehicle vehicle) : base(vehicle)
    {
    }

    public override void Display()
    {
        base.Vehicle.Display();
        Console.WriteLine("Light package: added");
    }
}
~~~

###### VehicleWithSmokerPackage
~~~c#
public class VehicleWithSmokerPackage : Decorator
{
    public VehicleWithSmokerPackage(Vehicle vehicle) : base(vehicle)
    {
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Smoker package: added");
    }
}
~~~

###### Usage
~~~c#
static void Main()
{
    var vehicle = new BaseCar();
    vehicle.Display();
    Console.WriteLine();

    var lightsCar = new VehicleWithLightPackage(vehicle);
    lightsCar.Display();
    Console.WriteLine();

    var smokerCar = new VehicleWithSmokerPackage(lightsCar);
    smokerCar.Display();
}
~~~

###### Output
![demo output](Images/Decorator-Output.png)
