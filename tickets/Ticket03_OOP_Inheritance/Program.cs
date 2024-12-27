// using System;
//
// namespace Ticket03_OOP_Inheritance
// {
//     // Класс "Треугольник"
//     public class Triangle
//     {
//         public double SideA { get; private set; }
//         public double SideB { get; private set; }
//         public double SideC { get; private set; }
//
//         // Конструктор
//         public Triangle(double sideA, double sideB, double sideC)
//         {
//             SideA = sideA;
//             SideB = sideB;
//             SideC = sideC;
//         }
//
//         // Метод проверки существования треугольника
//         public bool Exists()
//         {
//             return SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA;
//         }
//
//         // Метод вычисления периметра
//         public double Perimeter()
//         {
//             return SideA + SideB + SideC;
//         }
//
//         // Метод вычисления площади по формуле Герона
//         public double Area()
//         {
//             double semiPerimeter = Perimeter() / 2;
//             return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
//         }
//     }
//
//     // Класс "Пирамида", наследник класса "Треугольник"
//     public class Pyramid : Triangle
//     {
//         public double Height { get; private set; }
//
//         // Конструктор
//         public Pyramid(double sideA, double sideB, double sideC, double height)
//             : base(sideA, sideB, sideC)
//         {
//             Height = height;
//         }
//
//         // Переопределенный метод вычисления площади фигуры
//         public new double Area()
//         {
//             double baseArea = base.Area(); // Площадь основания (треугольника)
//             double slantHeight = Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Perimeter() / 3, 2)); // Апофема
//             double lateralArea = (Perimeter() * slantHeight) / 2;
//             return baseArea + lateralArea;
//         }
//     }
//
//     // Класс "Треугольная призма", наследник класса "Треугольник"
//     public class TriangularPrism : Triangle
//     {
//         public double Height { get; private set; }
//
//         // Конструктор
//         public TriangularPrism(double sideA, double sideB, double sideC, double height)
//             : base(sideA, sideB, sideC)
//         {
//             Height = height;
//         }
//
//         // Переопределенный метод вычисления площади фигуры
//         public new double Area()
//         {
//             double baseArea = base.Area(); // Площадь основания
//             double lateralArea = Perimeter() * Height; // Площадь боковых граней
//             return 2 * baseArea + lateralArea;
//         }
//     }
//
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Создание треугольника...");
//             Triangle triangle = new Triangle(3, 4, 5);
//
//             if (triangle.Exists())
//             {
//                 Console.WriteLine($"Периметр треугольника: {triangle.Perimeter()}");
//                 Console.WriteLine($"Площадь треугольника: {triangle.Area()}");
//             }
//             else
//             {
//                 Console.WriteLine("Треугольник с такими сторонами не существует.");
//             }
//
//             Console.WriteLine("\nСоздание пирамиды...");
//             Pyramid pyramid = new Pyramid(3, 4, 5, 6);
//             if (pyramid.Exists())
//             {
//                 Console.WriteLine($"Площадь пирамиды: {pyramid.Area()}");
//             }
//             else
//             {
//                 Console.WriteLine("Пирамида с таким основанием не существует.");
//             }
//
//             Console.WriteLine("\nСоздание треугольной призмы...");
//             TriangularPrism prism = new TriangularPrism(3, 4, 5, 10);
//             if (prism.Exists())
//             {
//                 Console.WriteLine($"Площадь треугольной призмы: {prism.Area()}");
//             }
//             else
//             {
//                 Console.WriteLine("Призма с таким основанием не существует.");
//             }
//         }
//     }
// }
//


using System;

namespace Ticket03_OOP_Inheritance
{
    // Класс "Треугольник"
    public class Triangle
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        // Конструктор
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        // Метод проверки существования треугольника
        public bool Exists()
        {
            return SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA;
        }

        // Метод вычисления периметра
        public double Perimeter()
        {
            return SideA + SideB + SideC;
        }

        // Метод вычисления площади по формуле Герона
        public double Area()
        {
            double semiPerimeter = Perimeter() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }
    }

    // Класс "Пирамида", наследник класса "Треугольник"
    public class Pyramid : Triangle
    {
        public double Height { get; private set; }

        // Конструктор
        public Pyramid(double sideA, double sideB, double sideC, double height)
            : base(sideA, sideB, sideC)
        {
            Height = height;
        }

        // Переопределенный метод вычисления площади фигуры
        public new double Area()
        {
            double baseArea = base.Area(); // Площадь основания (треугольника)
            double slantHeight = Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Perimeter() / 3, 2)); // Апофема
            double lateralArea = (Perimeter() * slantHeight) / 2;
            return baseArea + lateralArea;
        }
    }

    // Класс "Треугольная призма", наследник класса "Треугольник"
    public class TriangularPrism : Triangle
    {
        public double Height { get; private set; }

        // Конструктор
        public TriangularPrism(double sideA, double sideB, double sideC, double height)
            : base(sideA, sideB, sideC)
        {
            Height = height;
        }

        // Переопределенный метод вычисления площади фигуры
        public new double Area()
        {
            double baseArea = base.Area(); // Площадь основания
            double lateralArea = Perimeter() * Height; // Площадь боковых граней
            return 2 * baseArea + lateralArea;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание треугольника...");
            Console.Write("Введите стороны треугольника (через пробел): ");
            var triangleSides = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            Triangle triangle = new Triangle(triangleSides[0], triangleSides[1], triangleSides[2]);

            if (triangle.Exists())
            {
                Console.WriteLine($"Периметр треугольника: {triangle.Perimeter()}");
                Console.WriteLine($"Площадь треугольника: {triangle.Area()}");
            }
            else
            {
                Console.WriteLine("Треугольник с такими сторонами не существует.");
            }

            Console.WriteLine("\nСоздание пирамиды...");
            Console.Write("Введите стороны основания пирамиды и высоту (через пробел): ");
            var pyramidInputs = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            Pyramid pyramid = new Pyramid(pyramidInputs[0], pyramidInputs[1], pyramidInputs[2], pyramidInputs[3]);
            if (pyramid.Exists())
            {
                Console.WriteLine($"Площадь пирамиды: {pyramid.Area()}");
            }
            else
            {
                Console.WriteLine("Пирамида с таким основанием не существует.");
            }

            Console.WriteLine("\nСоздание треугольной призмы...");
            Console.Write("Введите стороны основания призмы и высоту (через пробел): ");
            var prismInputs = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            TriangularPrism prism = new TriangularPrism(prismInputs[0], prismInputs[1], prismInputs[2], prismInputs[3]);
            if (prism.Exists())
            {
                Console.WriteLine($"Площадь треугольной призмы: {prism.Area()}");
            }
            else
            {
                Console.WriteLine("Призма с таким основанием не существует.");
            }
        }
    }
}

