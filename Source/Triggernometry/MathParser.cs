/* 
 * Copyright (C) 2012-2016 Mathos Project,
 * All rights reserved.
 * 
 * Please see the license file in the project folder,
 * or go to https://github.com/MathosProject/Mathos-Parser/blob/master/LICENSE.
 * 
 * Please feel free to ask me directly at my email!
 *  artem@artemlos.net
 */

using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Triggernometry
{

    /// <summary>
    /// This is a mathematical expression parser that allows you to parser a string value,
    /// perform the required calculations, and return a value in form of a double number.
    /// </summary>
    public class MathParser
    {

        private static Random rng = new Random();

        static MathParser()
        {
            // Numeric Operators:

            // NOTE: All the characters in operators are considered as operator char. (except programmatically generated " ")
            // THE LIST IS IN ORDER AND THE LOWEST OPERATOR WILL BE EXECUTED FIRST.

            AddOperator("√", true, 1, unaryOperation: Math.Sqrt);
            AddOperator("!", true, 1, unaryOperation: a => IsZero(a) ? 1 : 0);                          // logic not  (!!a: double => "bool")
            AddOperator("~", true, 1, unaryOperation: a => ~Truncate(a));                               // bitwise not
            AddOperator(" *", false, 2, binaryOperation: (a, b) => a * b);                              // programmatically added "*"
            AddOperator("^", true, 2, binaryOperation: Math.Pow);
            AddOperator("%", false, 2, binaryOperation: (a, b) => a % b);                               // remainder
            AddOperator("%%", false, 2, binaryOperation: (a, b) => ModFunction(a, b));                  // modulo
            AddOperator("/", false, 2, binaryOperation: (a, b) => a / b);
            AddOperator("//", false, 2, binaryOperation: (a, b) => Math.Floor(a / b + TOLERANCE));      // exact division (always floor)
            AddOperator("*", false, 2, binaryOperation: (a, b) => a * b);
            // note that for any binary ops above this, "- a [op] b" is considered as "- (a [op] b)".
            // e.g.  - 2 ^ 2 = -4 (not 4);  - 9 %% 4 = -1 (not 3);  - 9 // 4 = -2 (not -3).
            // otherwise use (-a) [op] b.
            AddOperator("-", false, 2, binaryOperation: (a, b) => a - b);
            AddOperator("+", false, 2, binaryOperation: (a, b) => a + b);
            AddOperator("<<", false, 2, binaryOperation: (a, b) => Truncate(a) << (int)Truncate(b));         // bitwise left
            AddOperator(">>", false, 2, binaryOperation: (a, b) => Truncate(a) >> (int)Truncate(b));         // bitwise right
            AddOperator("??", true, 2);      // string operator: (a is numeric) ? a : b. Similar to null-coalescing operator ??
            AddOperator(">", false, 2, binaryOperation: (a, b) => a > b + TOLERANCE ? 1 : 0);
            AddOperator("≥", false, 2, binaryOperation: (a, b) => a + TOLERANCE >= b ? 1 : 0);
            AddOperator(">=", false, 2, binaryOperation: (a, b) => a + TOLERANCE >= b ? 1 : 0);
            AddOperator("<", false, 2, binaryOperation: (a, b) => a + TOLERANCE < b ? 1 : 0);
            AddOperator("≤", false, 2, binaryOperation: (a, b) => a <= b + TOLERANCE ? 1 : 0);
            AddOperator("<=", false, 2, binaryOperation: (a, b) => a <= b + TOLERANCE ? 1 : 0);
            AddOperator("==", false, 2);     // string operator: string equal
            AddOperator("=", false, 2, binaryOperation: (a, b) => IsZero(a - b) ? 1 : 0);
            AddOperator("≠", false, 2, binaryOperation: (a, b) => IsZero(a - b) ? 0 : 1);
            AddOperator("!=", false, 2, binaryOperation: (a, b) => IsZero(a - b) ? 0 : 1);
            AddOperator("&", false, 2, binaryOperation: (a, b) => Truncate(a) & Truncate(b));           // bitwise and
            AddOperator("⊕", false, 2, binaryOperation: (a, b) => Truncate(a) ^ Truncate(b));           // bitwise xor
            AddOperator("|", false, 2, binaryOperation: (a, b) => Truncate(a) | Truncate(b));           // bitwise or
            AddOperator("&&", false, 2, binaryOperation: (a, b) => (IsZero(a) || IsZero(b)) ? 0 : 1);   // logic and
            AddOperator("^^", false, 2, binaryOperation: (a, b) => (IsZero(a) == IsZero(b)) ? 0 : 1);   // logic xor
            AddOperator("||", false, 2, binaryOperation: (a, b) => (IsZero(a) && IsZero(b)) ? 0 : 1);   // logic or
            AddOperator("?", true, 3);                                                                  // ternary operator
            // Other operators: should not be directly executed, and the arity should be marked as 0.
            AddOperator(":", true, 0);    // parsed together with "?"
            AddOperator("(", false, 0);
            AddOperator(")", false, 0);
            AddOperator(",", false, 0);

            // Numeric Functions:
            // EACH FUNCTION MAY ONLY RETURN ONE *DOUBLE* VALUE (could be implicit).
            LocalFunctions.Add("abs", x => Math.Abs(x[0]));
            LocalFunctions.Add("cos", x => Math.Cos(x[0]));
            LocalFunctions.Add("cosh", x => Math.Cosh(x[0]));
            LocalFunctions.Add("arccos", x => Math.Acos(x[0]));
            LocalFunctions.Add("sec", x => 1.0 / Math.Cos(x[0]));
            LocalFunctions.Add("cosec", x => 1.0 / Math.Sin(x[0]));
            LocalFunctions.Add("csc", x => 1.0 / Math.Sin(x[0]));
            LocalFunctions.Add("cotan", x => 1.0 / Math.Tan(x[0]));
            LocalFunctions.Add("cot", x => 1.0 / Math.Tan(x[0]));
            LocalFunctions.Add("sin", x => Math.Sin(x[0]));
            LocalFunctions.Add("sinh", x => Math.Sinh(x[0]));
            LocalFunctions.Add("arcsin", x => Math.Asin(x[0]));
            LocalFunctions.Add("tan", x => Math.Tan(x[0]));
            LocalFunctions.Add("tanh", x => Math.Tanh(x[0]));
            LocalFunctions.Add("arctan", x => Math.Atan(x[0]));
            LocalFunctions.Add("arctan2", x => Math.Atan2(x[0], x[1]));
            LocalFunctions.Add("atan2", x => Math.Atan2(x[0], x[1]));
            LocalFunctions.Add("radtodeg", x => x[0] / Math.PI * 180.0);
            LocalFunctions.Add("degtorad", x => x[0] / 180.0 * Math.PI);
            LocalFunctions.Add("dir2rad", DirectionToRadFunction);
            LocalFunctions.Add("distance", DistanceFunction);
            LocalFunctions.Add("d", DistanceFunction);
            LocalFunctions.Add("manhattandistance", L1DistanceFunction);
            LocalFunctions.Add("l1d", L1DistanceFunction);
            LocalFunctions.Add("chebyshevdistance", LinfDistanceFunction);
            LocalFunctions.Add("l∞d", LinfDistanceFunction);
            LocalFunctions.Add("projectdistance", ProjectDistanceFunction);
            LocalFunctions.Add("projd", ProjectDistanceFunction);
            LocalFunctions.Add("projectheight", ProjectHeightFunction);
            LocalFunctions.Add("projh", ProjectHeightFunction);
            LocalFunctions.Add("ispointinray", IsPointInRayFunction);
            LocalFunctions.Add("angle", x => Math.Atan2(x[2] - x[0], x[3] - x[1]));
            LocalFunctions.Add("θ", x => Math.Atan2(x[2] - x[0], x[3] - x[1]));
            LocalFunctions.Add("relangle", x => ModFunction(x[1] - x[0] + Math.PI, 2 * Math.PI) - Math.PI);
            LocalFunctions.Add("relθ", x => ModFunction(x[1] - x[0] + Math.PI, 2 * Math.PI) - Math.PI);
            LocalFunctions.Add("isanglebetween", IsAngleBetweenFunction);
            LocalFunctions.Add("isθbetween", IsAngleBetweenFunction);
            LocalFunctions.Add("roundir", RoundirFunction);
            LocalFunctions.Add("roundvec", RoundvecFunction);
            LocalFunctions.Add("random", x => RandomNumber(x[0], x[1]));
            LocalFunctions.Add("sqrt", x => Math.Sqrt(x[0]));
            LocalFunctions.Add("rem", x => Math.IEEERemainder(x[0], x[1]));
            LocalFunctions.Add("mod", x => ModFunction(x[0], x[1]));
            LocalFunctions.Add("root", x => Math.Pow(x[0], 1.0 / x[1]));
            LocalFunctions.Add("pow", x => Math.Pow(x[0], x[1]));
            LocalFunctions.Add("exp", x => Math.Exp(x[0]));
            LocalFunctions.Add("log", LogFunction);
            LocalFunctions.Add("round", RoundFunction);
            LocalFunctions.Add("max", MaxFunction);
            LocalFunctions.Add("min", MinFunction);
            LocalFunctions.Add("truncate", x => Truncate(x[0]));
            LocalFunctions.Add("floor", x => Math.Floor(x[0] + TOLERANCE));
            LocalFunctions.Add("ceiling", x => Math.Ceiling(x[0] - TOLERANCE));
            LocalFunctions.Add("sign", x => IsZero(x[0]) ? 0 : Math.Sign(x[0]));
            LocalFunctions.Add("or", x => OrFunction(x));
            LocalFunctions.Add("and", x => AndFunction(x));
            LocalFunctions.Add("if", x => IfFunction(x[0], x[1], x[2]));

            // Numeric String Functions:
            // Mathparser string function parameters should not contain '('  ')'  ','  ' ' as part of the string.
            // Otherwise, should use ${func:...} instead.
            LocalStringFunctions.Add("hex2dec", x => Hex2DecFunction(x));
            LocalStringFunctions.Add("hex2float", x => Hex2FloatFunction(x));
            LocalStringFunctions.Add("hex2double", x => Hex2DoubleFunction(x));
            LocalStringFunctions.Add("X8float", x => Hex2FloatFunction(x));
            LocalStringFunctions.Add("parsedmg", x => ParseDamage(x));
            LocalStringFunctions.Add("len", x => x[0].Length);
            LocalStringFunctions.Add("freq", x => Frequency(x));
            LocalStringFunctions.Add("nextETms", x => NextETms(x));

            // Numeric Variables:
            // local variables such as pi can also be added into the parser.
            LocalVariables.Add("pi", 3.14159265358979323846264338327950288); // the simplest variable!
            LocalVariables.Add("π", 3.14159265358979323846264338327950288);
            LocalVariables.Add("pi2", 6.28318530717958647692528676655900576);
            LocalVariables.Add("pi05", 1.57079632679489661923132169163975144);
            LocalVariables.Add("pi025", 0.78539816339744830961566084581987572);
            LocalVariables.Add("pi0125", 0.39269908169872415480783042290993786);
            LocalVariables.Add("pitograd", 57.2957795130823208767981548141051704);
            LocalVariables.Add("piofgrad", 0.01745329251994329576923690768488612);
            LocalVariables.Add("pitorad", 57.2957795130823208767981548141051704);
            LocalVariables.Add("piofrad", 0.01745329251994329576923690768488612);
            LocalVariables.Add("e", 2.71828182845904523536028747135266249);
            LocalVariables.Add("phi", 1.61803398874989484820458683436563811);
            LocalVariables.Add("major", 0.61803398874989484820458683436563811);
            LocalVariables.Add("minor", 0.38196601125010515179541316563436189);
            LocalVariables.Add("ETmin2sec", ETmin2sec); // 70 / 24
            LocalVariables.Add("semitone", 1.059463094359295261164710035654);  // 2^(1/12)
            LocalVariables.Add("cent", 1.000577789506554859333888573259);      // 2^(1/1200)
            LocalVariables.Add("δ", TOLERANCE);
        }

        #region Numeric Functions (Definition)

        /// <summary> When comparing with an number n,
        /// all numbers in the range (n ± TOLERANCE) would all be considered as == n.
        /// double.Epsilon is too small for Triggernometry use.</summary>
        public const double TOLERANCE = 1E-9;
        public static bool IsZero(double x, double tolerance = TOLERANCE)
        {
            return Math.Abs(x) < tolerance;
        }

        public const double ETmin2sec = 70.0 / 24.0;

        public static long Truncate(double x, double tolerance = TOLERANCE)
        {
            if (x > 0)
                return (long)(x + tolerance);
            else
                return (long)(x - tolerance);
        }

        public static double ModFunction(double a, double b)
        {
            return (a % b + b) % b;
        }

        public static double IfFunction(double a, double b, double c)
        {
            return IsZero(a) ? c : b;
        }

        public static double OrFunction(double[] x)
        {
            if (x.Length == 0) { return 0; }
            foreach (double sx in x)
            {
                if (!IsZero(sx)) { return 1; }
            }
            return 0;
        }

        public static double AndFunction(double[] x)
        {
            if (x.Length == 0) { return 0; }
            foreach (double sx in x)
            {
                if (IsZero(sx)) { return 0; }
            }
            return 1;
        }

        /// <summary>
        /// Accepts 2n arguments: distance(*coord1, *coord2)
        /// e.g. distance(x1, y1, x2, y2)  distance(x1, y1, z1, x2, y2, z2)
        /// </summary>
        public static double DistanceFunction(double[] x)
        {   
            if (x.Length == 0 || x.Length % 2 != 0) { return 0; }
            int dimension = x.Length / 2;
            double squaresum = 0;
            for (int i = 0; i < dimension; i++)
            {
                squaresum += Math.Pow((x[i] - x[i + dimension]), 2.0);
            }
            return Math.Sqrt(squaresum);
        }

        /// <summary>
        /// Similar to Distance function, but L₁-distance (Manhattan distance).
        /// e.g. (x1, y1, x2, y2)  (x1, y1, z1, x2, y2, z2)
        /// </summary>
        public static double L1DistanceFunction(double[] x)
        {
            if (x.Length == 0 || x.Length % 2 != 0) { return 0; }
            int dimension = x.Length / 2;
            double d = 0;
            for (int i = 0; i < dimension; i++)
            {
                d += Math.Abs(x[i] - x[i + dimension]);
            }
            return d;
        }

        /// <summary>
        /// Similar to Distance function, but L∞-distance (Chebyshev distance).
        /// e.g. (x1, y1, x2, y2)  (x1, y1, z1, x2, y2, z2)
        /// </summary>
        public static double LinfDistanceFunction(double[] x)
        {
            if (x.Length == 0 || x.Length % 2 != 0) { return 0; }
            int dimension = x.Length / 2;
            double d = 0;
            for (int i = 0; i < dimension; i++)
            {
                d = Math.Max(d, Math.Abs(x[i] - x[i + dimension]));
            }
            return d;
        }

        // distance, projectdistance, projectheight
        // Using in-game coordination and direction defination:
        // Given point A (x1, y1), point B (x2, y2) and a ray with direction θ1 starting from A.
        // The project point of B on the ray direction is H.
        //
        // distance = |AB|
        // projectdistance = AH (directed distance, negative if H is on the other side)
        // projectheight = |BH|
        // AH² + BH² = AB²
        // Useful when doing calculations about line AoE.

        public static double ProjectDistanceFunction(double[] x)
        {   // projectdistance(x0, y0, θ0, x1, y1)
            if (x.Length != 5) { return 0; }
            double dx = x[3] - x[0];
            double dy = x[4] - x[1];
            double θ = x[2];
            return dx * Math.Sin(θ) + dy * Math.Cos(θ);
        }

        public static double ProjectHeightFunction(double[] x)
        {   // projectheight(x0, y0, θ0, x1, y1)
            if (x.Length != 5) { return 0; }
            double dx = x[3] - x[0];
            double dy = x[4] - x[1];
            double θ = x[2];
            return Math.Abs(dx * Math.Cos(θ) - dy * Math.Sin(θ));
        }

        public static double IsPointInRayFunction(double[] x)
        {   // ispointinray(x0, y0, θ0, width, x1, y1)
            if (x.Length != 6) { return 0; }
            double dx = x[4] - x[0];
            double dy = x[5] - x[1];
            double θ = x[2];
            double width = x[3];
            return Math.Abs(dx * Math.Cos(θ) - dy * Math.Sin(θ)) <= width && dx * Math.Sin(θ) + dy * Math.Cos(θ) >= 0 ? 1 : 0;
        }

        // roundir, roundvec
        // Matches the given direction in radian (roundir) or as a vector dx, dy (roundvec)
        // to the direction in a circle divided into 'n' segments, 
        // and returns the index of the direction (rounded to the nth decimal digit).
        // indexes: 0, 1, 2, ..., n-1, from north CCW.

        private static double ProcessRoundir(double rad, double segments, int digits = 0)
        {
            // 'segments' can be positive / negative. 
            // Positive means north is a segment point, while negative means north is the midpoint of two segment points.
            // e.g. 4: corresponds to cardinal directions (N = 0, W = 1, S = 2, E = 3);
            // -4: corresponds to intercardinal directions (NW = 0, SW = 1, SE = 2, NE = 3)

            double dir;
            if (segments > 0)
            {   // -pi => 0, pi => segments
                dir = (rad / Math.PI + 1) / 2 * segments;
            }
            else
            {   // -pi => -0.5, pi => segments - 0.5
                segments = -segments;
                dir = (rad / Math.PI + 1) / 2 * segments - 0.5;
            }

            // convert value range to [-0.5, segments - 0.5)
            dir = ModFunction(dir + 0.5, segments) - 0.5;
            return (digits >= 0) ? Math.Round(dir, digits) : dir;
        }

        public static double RoundirFunction(double[] input)
        {
            switch (input.Length)
            {
                case 2: // roundir(θ, segments)
                    return ProcessRoundir(input[0], input[1]);
                case 3: // roundir(θ, segments, digits)
                    return ProcessRoundir(input[0], input[1], (int)input[2]);
                default:
                    return 0;
            }
        }

        public static double RoundvecFunction(double[] input)
        {
            switch (input.Length)
            {
                case 3: // roundir(dx, dy, segments)
                    return ProcessRoundir(Math.Atan2(input[0], input[1]), input[2]);
                case 4: // roundir(dx, dy, segments, digits)
                    return ProcessRoundir(Math.Atan2(input[0], input[1]), input[2], (int)input[3]);
                default:
                    return 0;
            }
        }

        /// <summary> Reverse function of roundir.</summary>
        public static double DirectionToRadFunction(double[] input)
        {
            double direction = input[0];
            double segments = input[1];
            if (segments < 0)
            {
                segments *= -1;
                direction += 0.5;
            }
            return -Math.PI + 2 * Math.PI * ModFunction(direction / segments, 1);
        }

        /// <summary>
        /// Determine whether a given angle θ is within the range from θ1 to θ2 
        /// in the direction of increasing angles (counterclockwise in the game coordinate system). <br />
        /// The angles do not need to be in the range of -pi to pi.
        /// </summary>
        /// <param name="input">An array of { θ, θ1, θ2 }.</param>
        /// <returns>1 if between, else 0</returns>
        public static double IsAngleBetweenFunction(double[] input)
        {
            switch (input.Length)
            {
                case 3:
                    var θ  = ModFunction(input[0] + Math.PI, 2 * Math.PI) /*- Math.PI*/;
                    var θ1 = ModFunction(input[1] + Math.PI, 2 * Math.PI) /*- Math.PI*/;
                    var θ2 = ModFunction(input[2] + Math.PI, 2 * Math.PI) /*- Math.PI*/;
                    bool inRange = (θ1 <= θ2) ? (θ1 <= θ && θ <= θ2) : (θ1 <= θ || θ <= θ2);
                    return inRange ? 1 : 0;
                default:
                    return 0;
            }
        }

        public static int RandomNumber(double from, double to)
        {
            lock (rng)
            {
                return rng.Next((int)Math.Round(from), (int)Math.Round(to));
            }
        }

        public static double LogFunction(double[] input)
        {
            switch (input.Length)
            {
                case 1:
                    return Math.Log(input[0]);
                case 2:
                    return Math.Log(input[0], input[1]);
                default:
                    return 0;
            }
        }

        public static double RoundFunction(double[] input)
        {
            switch (input.Length)
            {
                case 1:
                    return Math.Round(input[0]);
                case 2:
                    return Math.Round(input[0], (int)input[1]);
                default:
                    return 0;
            }
        }

        public static double MaxFunction(double[] input)
        {
            double max = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                max = Math.Max(input[i], max);
            }
            return max;
        }

        public static double MinFunction(double[] input)
        {
            double min = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                min = Math.Min(input[i], min);
            }
            return min;
        }

        #endregion

        #region Numeric String Functions (Definition)

        public static double Hex2DecFunction(string[] x)
        {
            Int64 ex = Int64.Parse(x[0], NumberStyles.HexNumber, CultureInfo);
            double xy = ex;
            return xy;
        }

        public static double Hex2FloatFunction(string[] x)
        {
            Int32 bytesArray = Int32.Parse(x[0], NumberStyles.HexNumber, CultureInfo);
            float f = BitConverter.ToSingle(BitConverter.GetBytes(bytesArray), 0);
            return (double)f;
        }

        public static double Hex2DoubleFunction(string[] x)
        {
            Int64 bytesArray = Int64.Parse(x[0], NumberStyles.HexNumber, CultureInfo);
            double d = BitConverter.ToDouble(BitConverter.GetBytes(bytesArray), 0);
            return d;
        }

        public static double ParseDamage(string[] x)
        {
            return ParseDamage(x[0]);
        }

        public static double ParseDamage(string x)
        {
            string hexStr = x.PadLeft(8, '0');
            string hexDmg = hexStr.Substring(6, 2) + hexStr.Substring(0, 4);
            Int32 decDmg = Int32.Parse(hexDmg, NumberStyles.HexNumber, CultureInfo);
            return decDmg;
        }

        private static readonly Regex rexFreq = new Regex(@"(?<note>[A-G])(?<signs>[#bx]*)(?<octaves>\d+)");

        public static double Frequency(string[] x)
        {
            Match mx = rexFreq.Match(x[0]);
            if (mx.Success)
            {
                double semitones = (x.Length > 1) ? Parse(x[1]) : 0;
                string noteName = mx.Groups["note"].Value;
                switch (noteName)
                {
                    case "C": semitones += 0; break;
                    case "D": semitones += 2; break;
                    case "E": semitones += 4; break;
                    case "F": semitones += 5; break;
                    case "G": semitones += 7; break;
                    case "A": semitones += 9; break;
                    case "B": semitones += 11; break;
                }

                string signs = mx.Groups["signs"].Value;
                foreach (char c in signs)
                {
                    switch (c)
                    {
                        case '#': semitones += 1; break;
                        case 'x': semitones += 2; break;
                        case 'b': semitones -= 1; break;
                    }
                }

                int octaves = int.Parse(mx.Groups["octaves"].Value, CultureInfo);
                semitones += 12 * octaves;

                // A4 = 57 semitones relative to C0
                return 440 * Math.Pow(2, (semitones - 57) / 12.0);
            }
            else { return 0; }
        }
        /// <summary> returns the time (ms) to the next given ET.</summary>
        public static double NextETms(string[] input)
        {
            string etString = input[0];
            double totalMin = 0;
            try
            {
                if (etString.Contains(':'))
                {
                    double etHour = int.Parse(etString.Substring(0, etString.IndexOf(':')), CultureInfo);
                    double etMin = double.Parse(etString.Substring(etString.IndexOf(':') + 1), CultureInfo);
                    totalMin = etHour * 60.0 + etMin;
                    if (etHour < 0 || etMin < 0 || etMin > 60) { throw new Exception(); }
                }
                else
                {
                    totalMin = double.Parse(etString, CultureInfo);
                }
                if (totalMin < 0 || totalMin > 1440) { throw new Exception(); }
            }
            catch
            {
                throw Context.ParseTypeError(I18n.TranslateWord("string"), etString, I18n.TranslateWord("time"), $"nextETms({string.Join(", ", input)})");
            }

            TimeSpan ez = Context.GetEorzeanTime();
            return Math.Round((totalMin - ez.TotalMinutes + 1440) % 1440 * ETmin2sec * 1000);
        }

        #endregion

        #region Properties
        /// <summary> This function adds all properies of the operator: order, associative, arity, operation. </summary>
        /// <param name = "op" > The operator. Currently only supports single/double-character ops. </param>
        /// <param name = "isRightAssociative" > Searches the operator from the right side or the left side of the expression. </param>
        /// <param name = "arity" > 1: unary; 2: binary; 3: ternary; 0: Not parsed directly. </param>
        /// <param name = "unaryOperation" > The actual math function. Null if this operator is not unary. </param>
        /// <param name = "binaryOperation" > The actual math function. Null if this operator is not binary. </param>
        private static void AddOperator(string op, bool isRightAssociative, int arity,
            Func<double, double> unaryOperation = null, Func<double, double, double> binaryOperation = null)
        {
            if (arity != 0)                 // add the actually used operators (for calculation)
            {
                OperatorOrder.Add(op);
                OperatorRightAssociative[op] = isRightAssociative;
            }
            OperatorArity[op] = arity;
            if (op != " *")
            {
                OperatorChar.UnionWith(op);    // add the chars which are considered as operator chars (for lexer)
            }

            if (arity == 1)
            {
                UnaryOperation[op] = unaryOperation;
            }
            else if (arity == 2)
            {
                BinaryOperation[op] = binaryOperation;
            }
        }

        /// <summary> The list contains all operators in the execution order. </summary>
        public static List<string> OperatorOrder { get; set; } = new List<string>();
        /// <summary> The list contains all characters in the operators. For checking if a char is part of a op.</summary>
        public static HashSet<char> OperatorChar { get; set; } = new HashSet<char>();
        /// <summary> The operators are right-associative or not. </summary>
        public static Dictionary<string, bool> OperatorRightAssociative = new Dictionary<string, bool>();
        /// <summary> The operators are unary, binary or ternary. Also for checking if a string is a op.</summary>
        public static Dictionary<string, int> OperatorArity = new Dictionary<string, int>();
        public static Dictionary<string, Func<double, double, double>> BinaryOperation { get; set; } =
            new Dictionary<string, Func<double, double, double>>();
        public static Dictionary<string, Func<double, double>> UnaryOperation { get; set; } =
            new Dictionary<string, Func<double, double>>();

        /// <summary> All functions that you want to define should be inside this property. </summary>
        public static Dictionary<string, Func<double[], double>> LocalFunctions { get; set; } =
            new Dictionary<string, Func<double[], double>>();

        public static Dictionary<string, Func<string[], double>> LocalStringFunctions { get; set; } =
            new Dictionary<string, Func<string[], double>>();

        /// <summary> All variables that you want to define should be inside this property. </summary>
        public static Dictionary<string, double> LocalVariables { get; set; } = new Dictionary<string, double>();

        /// <summary>
        /// When converting the result from the Parse method or ProgrammaticallyParse method ToString(),
        /// please use this cultur info.
        /// </summary>
        public static CultureInfo CultureInfo { get; } = CultureInfo.InvariantCulture;

        #endregion

        #region Core

        /// <summary> Enter the math expression in form of a string. </summary>
        /// <param name="mathExpression"></param>
        public static double Parse(string mathExpression)
        {
            return MathParserLogic(Lexer(mathExpression));
        }

        /// <summary> Enter the math expression in form of a list of tokens. </summary>
        /// <param name="mathExpression"></param>
        public double Parse(ReadOnlyCollection<string> mathExpression)
        {
            return MathParserLogic(new List<string>(mathExpression));
        }

        /// <summary>
        /// This will convert a string expression into a list of tokens that 
        /// can be later executed by Parse or ProgrammaticallyParse methods.
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <returns>A ReadOnlyCollection</returns>
        public ReadOnlyCollection<string> GetTokens(string mathExpression)
        {
            return Lexer(mathExpression).AsReadOnly();
        }

        private static Regex MultiplePlusMinus = new Regex(@"[-+][-+ ]*[-+]");

        /// <summary> Tokenizes <paramref name="expr"/>. </summary>
        /// <param name="expr">The expression.</param>
        /// <returns>Tokens found <paramref name="expr"/>.</returns>
        internal static List<string> Lexer(string expr)
        {
            var tokens = new List<string>();

            // delete all spaces to avoid the splitting error of +/- when parsing strings like "1 + -1".
            // ignore all \r and \n to support multi-line input when writing long expressions
            expr = expr.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace(Context.LINEBREAK_PLACEHOLDER.ToString(), "");

            // degree → rad
            expr = expr.Replace("°", "*0.01745329251994329576923690768488612");

            // replace continuous +/- to a single +/- base on the count of "-"
            expr = MultiplePlusMinus.Replace(expr, match => match.Value.Count(c => c == '-') % 2 == 0 ? "+" : "-");

            for (var i = 0; i < expr.Length; i++)
            {   // traverse all chars in the expression
                char ch = expr[i];
                // A segmentation of non-operator chars:
                // const (pi), func (sin), numbers (123), numeric string func arguments (E000)
                // Note: this could contain invalid chars and throw customized errors in ParseBasicMathExpression(). 
                if (!OperatorChar.Contains(ch))
                {
                    if (i != 0 && expr[i - 1] == ')')   // add omitted '*':  (-1)sin(0) => (-1) * sin(0)
                    {
                        tokens.Add("*");
                    }
                    int start = i;
                    while (i + 1 < expr.Length && !OperatorChar.Contains(expr[i + 1])) { i++; }
                    tokens.Add(expr.Substring(start, i - start + 1)); // add the segmentation as a token
                }
                else // operators
                {
                    string op;
                    // double-char operators
                    if (i + 1 < expr.Length && OperatorArity.ContainsKey(expr.Substring(i, 2)))
                    {
                        op = expr.Substring(i, 2);
                    }
                    // single-char operators including , ( )
                    else
                    {
                        op = ch.ToString();
                    }
                    // add a " *" if the previous char is not an operator and the previous token is not a function.
                    // 2(1+3) => 2 *(1+3)  pi(1+3) => pi *(1+3)  sin(1+3) => unchanged  6√3 => 6 *√3
                    // " *" has the highest prio among all binary ops.
                    if (op == "(" || OperatorArity[op] == 1)
                    {
                        if (i != 0
                            && (!OperatorChar.Contains(expr[i - 1]) || expr[i - 1] == ')')  // prev char is operator
                            && tokens.Count > 0
                            && !LocalFunctions.ContainsKey(tokens[tokens.Count - 1])        // prev token is not function
                            && !LocalStringFunctions.ContainsKey(tokens[tokens.Count - 1])
                            )
                            tokens.Add(" *"); // add this " *" operator with the highest order among all binary ops
                    }

                    tokens.Add(op);
                    if (op.Length == 2) { i++; }
                }
            }
            return tokens;
        }

        private static readonly Regex regexHexNumber = new Regex(@"^0x[0-9A-Fa-f]+$", RegexOptions.Compiled);
        private static readonly Regex regexBinNumber = new Regex(@"^0b[01]+$", RegexOptions.Compiled);
        private static readonly Regex regexOctNumber = new Regex(@"^0o[0-7]+$", RegexOptions.Compiled);

        internal static double MathParserLogic(List<string> tokens)
        {
            // for error information
            var originalTokens = tokens.ToArray();

            // Variables replacement: pi => 3.14159...
            // Hex number replacement: 0xA0 => 160
            for (var i = 0; i < tokens.Count; i++)
            {
                if (LocalVariables.TryGetValue(tokens[i], out var variableValue))
                {
                    tokens[i] = variableValue.ToString(CultureInfo);
                    continue;
                }

                if (tokens[i].Length <= 2) continue; 
                switch (tokens[i].Substring(0, 2))
                {
                    case "0x":
                        if (regexHexNumber.Match(tokens[i]).Success)
                            tokens[i] = Convert.ToInt64(tokens[i].Substring(2), 16).ToString(CultureInfo);
                        break;
                    case "0b":
                        if (regexBinNumber.Match(tokens[i]).Success)
                            tokens[i] = Convert.ToInt64(tokens[i].Substring(2), 2).ToString(CultureInfo);
                        break;
                    case "0o":
                        if (regexOctNumber.Match(tokens[i]).Success)
                            tokens[i] = Convert.ToInt64(tokens[i].Substring(2), 8).ToString(CultureInfo);
                        break;
                    default:
                        break;
                }
            }
            
            for (var i = 0; i < tokens.Count; i++)
            {
                if (LocalVariables.Keys.Contains(tokens[i]))
                    tokens[i] = LocalVariables[tokens[i]].ToString(CultureInfo);
            }

            while (tokens.IndexOf("(") != -1)
            {
                // getting data between "(" and ")"
                var open = tokens.LastIndexOf("(");
                var close = tokens.IndexOf(")", open);
                if (open >= close || open < 0)
                {
                    throw new ArithmeticException(I18n.Translate("internal/MathParser/noclosure",
                        "Parenthesis not closed in math expression: '{0}'. Original expression: ({1})", 
                        string.Join(" ", tokens), string.Join(" ", originalTokens)));
                }

                // create a sublist of the tokens inside (...)
                var exprTokens = new List<string>();
                for (var i = open + 1; i < close; i++)
                    exprTokens.Add(tokens[i]);

                double tmpResult;

                var args = new List<double>();
                var sargs = new List<string>();
                var functionName = tokens[open == 0 ? 0 : open - 1];

                if (LocalFunctions.Keys.Contains(functionName))
                {
                    if (exprTokens.Contains(","))
                    {
                        // converting all arguments into a decimal array
                        // 'a' ',' 'b' 'c' ',' 'd' 'e' 'f' => [a, bc, def]
                        for (var i = 0; i < exprTokens.Count; i++)
                        {
                            var defaultExpr = new List<string>();
                            var firstCommaOrEndOfExpression = (exprTokens.IndexOf(",", i) != -1)
                                ? exprTokens.IndexOf(",", i)
                                : exprTokens.Count;

                            while (i < firstCommaOrEndOfExpression)
                                defaultExpr.Add(exprTokens[i++]);

                            args.Add(ParseBasicMathExpression(defaultExpr, originalTokens));
                        }

                        // finally, passing the arguments to the given function
                        tmpResult = LocalFunctions[functionName](args.ToArray());
                    }
                    else
                    {
                        // but if we only have one argument, then we pass it directly to the function
                        tmpResult = LocalFunctions[functionName](new[] { ParseBasicMathExpression(exprTokens, originalTokens) });
                    }
                }
                else if (LocalStringFunctions.Keys.Contains(functionName))
                {
                    if (exprTokens.Contains(",") && functionName != "len")
                    {
                        // converting all arguments into a decimal array
                        for (var i = 0; i < exprTokens.Count; i++)
                        {
                            var defaultExpr = new List<string>();
                            var firstCommaOrEndOfExpression = (exprTokens.IndexOf(",", i) != -1)
                                ? exprTokens.IndexOf(",", i)
                                : exprTokens.Count;

                            while (i < firstCommaOrEndOfExpression)
                                defaultExpr.Add(exprTokens[i++]);
                            string argExpr = string.Join("", defaultExpr);
                            sargs.Add(argExpr);
                        }

                        // finally, passing the arguments to the given function
                        tmpResult = LocalStringFunctions[functionName](sargs.ToArray());
                    }
                    else
                    {
                        // but if we only have one argument, then we pass it directly to the function
                        string argExpr = string.Join("", exprTokens);
                        tmpResult = LocalStringFunctions[functionName](new string[] { argExpr });
                    }
                }
                else
                {
                    // if no function is need to execute following expression, pass it
                    // to the "ParseBasicMathExpression" method.
                    tmpResult = ParseBasicMathExpression(exprTokens, originalTokens);
                }

                // when all the calculations have been done
                // we replace the "opening bracket with the result"
                // and removing the rest.
                tokens[open] = tmpResult.ToString(CultureInfo);
                tokens.RemoveRange(open + 1, close - open);

                if (LocalFunctions.Keys.Contains(functionName))
                {
                    // if we also executed a function, removing
                    // the function name as well.
                    tokens.RemoveAt(open - 1);
                }
                else if (LocalStringFunctions.Keys.Contains(functionName))
                {
                    // if we also executed a function, removing
                    // the function name as well.
                    tokens.RemoveAt(open - 1);
                }
            }

            // at this point, we should have replaced all brackets
            // with the appropriate values, so we can simply
            // calculate the expression. it's not so complex
            // any more!
            return ParseBasicMathExpression(tokens, originalTokens);
        }

        private static double ParseBasicMathExpression(List<string> tokens, string[] originalTokens)
        {
            // PERFORMING A BASIC ARITHMETICAL EXPRESSION CALCULATION
            // THIS METHOD CAN ONLY OPERATE WITH NUMBERS AND OPERATORS
            // AND WILL NOT UNDERSTAND ANYTHING BEYOND THAT (like parenthesis and functions).

            try
            {   // optimize for 0-2 tokens
                switch (tokens.Count)
                {
                    case 0:
                        return 0;
                    case 1:
                        return (tokens[0] == "==") ? 1 : double.Parse(tokens[0], CultureInfo);
                    case 2:
                        if (tokens[0] == "+" || tokens[0] == "-")
                        {
                            ApplyPlusMinusToNumber(tokens, 0);
                            return double.Parse(tokens[0], CultureInfo);
                        }
                        else if (tokens.Contains("=="))
                        {
                            return 0;
                        }
                        else if (tokens[0] == "??")
                        {
                            return double.Parse(tokens[1], CultureInfo);
                        }
                        else
                        {
                            return UnaryOperation[tokens[0]](double.Parse(tokens[1], CultureInfo));
                        }
                }
            }
            catch
            {
                throw new ArithmeticException(I18n.Translate("internal/MathParser/basicMathExprError",
                    "The basic math expression: '{0}' could not be parsed. Original expression: '{1}'",
                    string.Join(" ", tokens), string.Join(" ", originalTokens)));
            }

            foreach (string op in OperatorOrder)
            {
                try
                {
                    // string operator
                    if (op == "==")
                    {
                        while (tokens.IndexOf(op) != -1)
                        {
                            int opPlace = tokens.IndexOf(op);
                            ApplyStringEqual(tokens, opPlace);
                        }
                        continue;
                    }
                    if (op == "??")
                    {
                        while (tokens.IndexOf(op) != -1)
                        {
                            int opPlace = tokens.LastIndexOf(op);
                            ApplyStringCoalescing(tokens, opPlace, originalTokens);
                        }
                        continue;
                    }
                    // numeric operators
                    switch (OperatorArity[op])
                    {
                        case 1:
                            while (tokens.IndexOf(op) != -1)
                            {
                                var opPlace = (OperatorRightAssociative[op]) ? tokens.LastIndexOf(op) : tokens.IndexOf(op);
                                if (tokens[opPlace + 1] == "+" || tokens[opPlace + 1] == "-")
                                {
                                    ApplyPlusMinusToNumber(tokens, opPlace + 1);
                                }
                                var numberA = double.Parse(tokens[opPlace + 1], CultureInfo);
                                var result = UnaryOperation[op](numberA);
                                if (double.IsNaN(result) || double.IsInfinity(result)) { throw new Exception(); }
                                tokens[opPlace + 1] = result.ToString(CultureInfo);
                                tokens.RemoveAt(opPlace);
                            }
                            break;
                        case 2:
                            while (tokens.IndexOf(op) != -1)
                            {
                                var opPlace = (OperatorRightAssociative[op]) ? tokens.LastIndexOf(op) : tokens.IndexOf(op);

                                if ((op == "+" || op == "-")
                                    && (opPlace == 0 || OperatorArity.ContainsKey(tokens[opPlace - 1])))
                                {   // the current op is plus/minus
                                    ApplyPlusMinusToNumber(tokens, opPlace);
                                    continue;
                                }
                                if (tokens[opPlace + 1] == "+" || tokens[opPlace + 1] == "-")
                                {   // the next op is plus/minus when dealing with the current higher-prio operator
                                    ApplyPlusMinusToNumber(tokens, opPlace + 1);
                                }
                                var numberA = double.Parse(tokens[opPlace - 1], CultureInfo);
                                var numberB = double.Parse(tokens[opPlace + 1], CultureInfo);
                                var result = BinaryOperation[op](numberA, numberB);
                                if (double.IsNaN(result) || double.IsInfinity(result)) { throw new Exception(); }
                                tokens[opPlace - 1] = result.ToString(CultureInfo);
                                tokens.RemoveRange(opPlace, 2);
                            }
                            break;
                        case 3: // currently only for  "? :"
                            while (tokens.IndexOf(op) != -1)
                            {
                                //var opPlace = (OperatorRightAssociative[op]) ? tokens.LastIndexOf(op) : tokens.IndexOf(op);
                                var opPlace = tokens.LastIndexOf(op);
                                if (tokens[opPlace + 2] != ":") { throw new Exception(); }
                                var result = IsZero(double.Parse(tokens[opPlace - 1], CultureInfo)) 
                                           ? double.Parse(tokens[opPlace + 3], CultureInfo)
                                           : double.Parse(tokens[opPlace + 1], CultureInfo);
                                // if (double.IsNaN(result) || double.IsInfinity(result)) { throw new Exception(); }
                                tokens[opPlace - 1] = result.ToString(CultureInfo);
                                tokens.RemoveRange(opPlace, 4);
                            }
                            break;
                        default: throw new Exception();
                    }
                }
                catch
                {
                    throw new ArithmeticException(I18n.Translate("internal/MathParser/basicMathExprOpError",
                        "The operation '{0}' from the basic math expression: '{1}' could not be applied. Original expression: '{2}'",
                        op, string.Join(" ", tokens), string.Join(" ", originalTokens)));
                }
            }
            return double.Parse(tokens[0], CultureInfo);
        }
        /// <summary> Combine the plus/minus and the next number in the tokens list. </summary>
        private static void ApplyPlusMinusToNumber(List<string> tokens, int opIndex)
        {
            string pm = tokens[opIndex];
            tokens.RemoveAt(opIndex);
            if (pm == "-")
            {                                                           // [opIndex] is now the next number to be applied +/- on.
                tokens[opIndex] = (tokens[opIndex].StartsWith("-"))     // It is impossible to have a token starting with "+" now.
                                ? tokens[opIndex].Substring(1)          // "-11" => "11"
                                : "-" + tokens[opIndex];                // "11" => "-11"
            }                                                           // pm == "+" is ignored
        }

        private static void ApplyStringEqual(List<string> tokens, int opIndex)
        {
            if (tokens.Count == 1)                  // ["=="]
            {
                tokens[opIndex] = "1";
            }
            else if (opIndex == 0)                  // ["==", ...]
            {
                tokens[opIndex + 1] = "0";
                tokens.RemoveRange(opIndex, 1);
            }
            else if (opIndex == tokens.Count - 1)   // [..., "=="]
            {
                tokens[opIndex - 1] = "0";
                tokens.RemoveRange(opIndex, 1);
            }
            else                                    // [..., "==", ...]
            {
                string result = (tokens[opIndex - 1] == tokens[opIndex + 1]) ? "1" : "0";
                tokens[opIndex - 1] = result;
                tokens.RemoveRange(opIndex, 2);
            }
        }

        private static void ApplyStringCoalescing(List<string> tokens, int opIndex, string[] originalTokens)
        {   // a ?? b  means  (a is numeric) ? a : b
            if (opIndex == tokens.Count - 1)        // [..., "??"]
            {
                throw new ArithmeticException(I18n.Translate("internal/MathParser/basicMathExprOpError",
                    "The operation '{0}' from the basic math expression: '{1}' could not be applied. Original expression: '{2}'",
                    "??", string.Join(" ", tokens), string.Join(" ", originalTokens)));
            }
            else if (opIndex == 0)                  // ["??", ...]
            {
                tokens.RemoveRange(opIndex, 1);
            }
            else                                    // [..., "??", ...]
            {
                bool isNumeric = double.TryParse(tokens[opIndex - 1], NumberStyles.Float, CultureInfo, out double numberA);
                if (isNumeric) { tokens.RemoveRange(opIndex, 2); }
                else { tokens.RemoveRange(opIndex - 1, 2); }
            }
        }

        #endregion
    }

}
