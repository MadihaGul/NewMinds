using System;

public class RainStorm:Storm
{
    public RainStorm(double eyeRadius, Tuple<double, double> eyePosition)
    {
        this.EyeRadius = eyeRadius;
        this.EyePosition = eyePosition;
    }

   
    public double AmountOfRain()
    {
        return EyeRadius * 20;
    }
}

public class SnowStorm : Storm
{
    public double AmountOfSnow { get; private set; }

    public SnowStorm(double eyeRadius, Tuple<double, double> eyePosition, double amountOfSnow)
    {
        this.EyeRadius = eyeRadius;
        this.EyePosition = eyePosition;
        this.AmountOfSnow = amountOfSnow;
    }

}

public class Storm
{
    public double EyeRadius { get; protected set; }
    public Tuple<double, double> EyePosition { get; protected set; }

    public bool IsInEyeOfTheStorm(Tuple<double, double> position)
    {
        double distance = Math.Sqrt(Math.Pow(position.Item1 - EyePosition.Item1, 2) +
                                    Math.Pow(position.Item2 - EyePosition.Item2, 2));
        return distance < EyeRadius;
    }

}








public class DriverExam
{
    public static void ExecuteExercise(IExercise exercise)
    {
        try
        {
            exercise.Start();

            exercise.Execute();

            exercise.End();
        }
        catch
        {
            exercise.MarkNegativePoints();
        }

        
    }
}

public interface IExercise
{
    void Start();
    void Execute();
    void MarkNegativePoints();
    void End();
}

public class Exercise : IExercise
{
    public void Start() { Console.WriteLine("Start"); }
    public void Execute() { Console.WriteLine("Execute"); }
    public void MarkNegativePoints() { Console.WriteLine("MarkNegativePoints"); }
    public void End() { Console.WriteLine("End"); }
}

public class Program
{
    public static void Main(string[] args)
    {
        DriverExam.ExecuteExercise(new Exercise());
    }
}