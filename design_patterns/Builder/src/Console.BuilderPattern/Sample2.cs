CarBuilder builder = new();
Director director = new();

director.ConstructSportsCar(builder);
Car car = builder.Build();
Console.WriteLine($"Car built: {car.CarType}");

ManualCarBuilder manualBuilder = new();
director.ConstructCityCar(manualBuilder);
ManualCar manualCar = manualBuilder.Build();

Console.WriteLine($"Manual car built: {manualCar.CarType}");



enum CarType
{
    CityCar,
    SportsCar,
    Suv,
}

enum Transmission
{
    SingleSpeed,
    Manual,
    Automatic,
    SemiAutomatic,
}

class Engine
{
    public double Volume { get; set; }
    public double Mileage { get; set; }
    public bool Started { get; set; }

    public void On()
    {
        Started = true;
    }

    public void Off()
    {
        Started = false;
    }

    public void Go(double mileage)
    {
        if (Started)
            Mileage += mileage;
        else
            Console.WriteLine("Cannot go(), you must start engine first!");
    }
}

class GpsNavigator
{
    public string Route { get; set; }

    public GpsNavigator()
    {
        Route = "221b, Baker Street, London to Scotland Yard, 8-10 Broadway, London";
    }
}

interface ICar
{
    
}

class Car(
    CarType carType, 
    short seats, 
    Engine engine, 
    Transmission transmission, 
    GpsNavigator gpsNavigator, 
    double fuel) : ICar
{
    public CarType CarType { get; set; } = carType;
    public Engine Engine { get; set; } = engine;
    public GpsNavigator GpsNavigator { get; set; } = gpsNavigator;
    public short Seats { get; set; } = seats;
    public Transmission Transmission { get; set; } = transmission;
    public double Fuel { get; set; } = fuel;
}

class ManualCar(
    CarType carType, 
    short seats, 
    Engine engine, 
    Transmission transmission, 
    GpsNavigator gpsNavigator)  : ICar
{
    public CarType CarType { get; set; } = carType;
    public Engine Engine { get; set; } = engine;
    public GpsNavigator GpsNavigator { get; set; } = gpsNavigator;
    public short Seats { get; set; } = seats;
    public Transmission Transmission { get; set; } = transmission;
}

interface IBuilder<T> where T: ICar
{
    void SetCarType(CarType carType);
    void SetSeats(short seats);
    void SetEngine(Engine engine);
    void SetTransmission(Transmission transmission);
    void SetGpsNavigator(GpsNavigator gpsNavigator);
    T Build();
}

class CarBuilder : IBuilder<Car>
{
    private readonly Car _car = new(CarType.CityCar, 2, new Engine(), Transmission.Automatic, new GpsNavigator(), 0);

    public void SetCarType(CarType carType)
    {
        _car.CarType = carType;
    }

    public void SetSeats(short seats)
    {
        _car.Seats = seats;
    }

    public void SetEngine(Engine engine)
    {
        _car.Engine = engine;
    }

    public void SetTransmission(Transmission transmission)
    {
        _car.Transmission = transmission;
    }

    public void SetGpsNavigator(GpsNavigator gpsNavigator)
    {
        _car.GpsNavigator = gpsNavigator;
    }

    public Car Build()
    {
        return _car;
    }
}

class ManualCarBuilder : IBuilder<ManualCar>
{
    private readonly ManualCar _manualCar = new(CarType.CityCar, 2, new Engine(), Transmission.Manual, new GpsNavigator());
    
    public void SetCarType(CarType carType)
    {
        _manualCar.CarType = carType;        
    }

    public void SetSeats(short seats)
    {
        _manualCar.Seats = seats;
    }

    public void SetEngine(Engine engine)
    {
        _manualCar.Engine = engine;
    }

    public void SetTransmission(Transmission transmission)
    {
        _manualCar.Transmission = transmission;
    }

    public void SetGpsNavigator(GpsNavigator gpsNavigator)
    {
        _manualCar.GpsNavigator = gpsNavigator;
    }
        
    public ManualCar Build()
    {
        return _manualCar;
    }
}

class Director
{
    public void ConstructCityCar(IBuilder<ManualCar> builder)
    {
        builder.SetCarType(CarType.CityCar);
        builder.SetSeats(2);
        builder.SetEngine(new Engine { Volume = 1.2, Mileage = 0 });
        builder.SetTransmission(Transmission.Automatic);
        builder.SetGpsNavigator(new GpsNavigator());
    }
    
    public void ConstructSportsCar(IBuilder<Car> builder)
    {
        builder.SetCarType(CarType.SportsCar);
        builder.SetSeats(2);
        builder.SetEngine(new Engine { Volume = 3.0, Mileage = 0 });
        builder.SetTransmission(Transmission.SemiAutomatic);
        builder.SetGpsNavigator(new GpsNavigator());
    }
    
    public void ConstructSuv(IBuilder<Car> builder)
    {
        builder.SetCarType(CarType.Suv);
        builder.SetSeats(4);
        builder.SetEngine(new Engine { Volume = 2.5, Mileage = 0 });
        builder.SetTransmission(Transmission.Manual);
        builder.SetGpsNavigator(new GpsNavigator());
    }
}
