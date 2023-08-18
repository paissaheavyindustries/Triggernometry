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
    /// perform the required calculations, and return a value in form of a decimal.
    /// </summary>
    public class MathParser
    {

        private static Random rng = new Random();

        public double Hex2DecFunction(string[] x)
        {
            int ex = int.Parse(x[0], System.Globalization.NumberStyles.HexNumber);
            double xy = ex;
            return xy;
        }

        public double Hex2FloatFunction(string[] x)
        {
            Int32 bytesArray = Int32.Parse(x[0], System.Globalization.NumberStyles.HexNumber);
            float f = BitConverter.ToSingle(BitConverter.GetBytes(bytesArray), 0);
            return (double)f;
        }

        public double Hex2DoubleFunction(string[] x)
        {
            Int64 bytesArray = Int64.Parse(x[0], System.Globalization.NumberStyles.HexNumber);
            double d = BitConverter.ToDouble(BitConverter.GetBytes(bytesArray), 0);
            return d;
        }

        public double ParseDmgFunction(string[] x)
        {
            string hexStr = x[0].PadLeft(8, '0');
            string hexDmg = hexStr.Substring(6, 2) + hexStr.Substring(0, 4);
            Int32 decDmg = Int32.Parse(hexDmg, System.Globalization.NumberStyles.HexNumber);
            return (double)decDmg;
        }

        private static readonly Regex rexFreq = new Regex(@"(?<note>[A-G])(?<signs>[#bx]*)(?<octaves>\d+)");
        public double FreqFunction(string[] x)
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

                int octaves = int.Parse(mx.Groups["octaves"].Value);
                semitones += 12 * octaves;
                

                // A4 = 57 semitones relative to C0
                return 440 * Math.Pow(2, (semitones - 57.0) / 12);
            }
            else
            {
                return 0;
            }
        }

        public double IfFunction(double a, double b, double c)
        {
            return (a == 0) ? c : b;
        }

        public double OrFunction(double[] x)
        {
            if (x.Length == 0)
            {
                return 0;
            }
            foreach (double sx in x)
            {
                if (Math.Abs(sx) > double.Epsilon)
                {
                    return 1;
                }
            }
            return 0;
        }

        public double AndFunction(double[] x)
        {
            if (x.Length == 0)
            {
                return 0;
            }
            foreach (double sx in x)
            {
                if (Math.Abs(sx) < double.Epsilon)
                {
                    return 0;
                }
            }
            return 1;
        }

        public double DistanceFunction(double[] x)
        {   // accepts 2n arguments: distance(*coord1, *coord2)
            // e.g. distance(x1, y1, x2, y2)  distance(x1, y1, z1, x2, y2, z2)
            if (x.Length == 0 || x.Length % 2 != 0)
                return 0;

            int dimension = x.Length / 2;
            double squaresum = 0;
            for (int i = 0; i < dimension; i++)
            {
                squaresum += Math.Pow((x[i] - x[i + dimension]), 2.0);
            }
            return Math.Sqrt(squaresum);
        }

        public double ProjectDistanceFunction(double[] x)
        {   // projectdistance(x1, y1, θ1, x2, y2)

            if (x.Length != 5)
                return 0;

            double dx = x[3] - x[0];
            double dy = x[4] - x[1];
            double θ = x[2];
            return dx * Math.Sin(θ) + dy * Math.Cos(θ);
        }

        public double ProjectHeightFunction(double[] x)
        {   // projectheight(x1, y1, θ1, x2, y2)

            if (x.Length != 5)
                return 0;

            double dx = x[3] - x[0];
            double dy = x[4] - x[1];
            double θ = x[2];
            return Math.Abs(dx * Math.Cos(θ) - dy * Math.Sin(θ));
        }

        private double ProcessRoundir(double rad, double segments, int digits = 0)
        {
            // 'segments' can be positive / negative. 
            // Positive means north is a segment point, while negative means north is the midpoint of two segment points.
            // e.g. 4: corresponds to cardinal directions (N = 0, W = 1, S = 2, E = 3);
            // -4: corresponds to intercardinal directions (NW = 0, SW = 1, SE = 2, NE = 3)

            // normalize radian to [-π, π)
            rad = ((rad + Math.PI) % (2 * Math.PI) + 2 * Math.PI) % (2 * Math.PI) - Math.PI;
            double dir = 0;
            if (segments > 0)
            {   
                dir = (rad + Math.PI) / (2 * Math.PI) * segments;
                // convert value range: [0, segments] => [0, segments)
                dir = (dir == segments) ? 0 : dir;  
            }
            else if (segments < 0)
            {   
                segments = -segments;
                dir = (rad + Math.PI) / (2 * Math.PI) * segments - 0.5;
                // convert value range: [-0.5, segments - 0.5] => [-0.5, segments - 0.5)
                dir = (dir == segments - 0.5) ? -0.5 : dir;  
            }

            if (digits >= 0)
                return Math.Round(dir, digits);
            else
                return dir;
        }

        public double RoundirFunction(double[] input)
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
        public double RoundvecFunction(double[] input)
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

        public int RandomNumber(double from, double to)
        {
            lock (rng)
            {
                return rng.Next((int)Math.Round(from), (int)Math.Round(to));
            }
        }

        /// <summary>
        /// This constructor will add some basic operators, functions, and variables
        /// to the parser. Please note that you are able to change that using
        /// boolean flags
        /// </summary>
        /// <param name="loadPreDefinedFunctions">This will load "abs", "cos", "cosh", "arccos", "sin", "sinh", "arcsin", "tan", "tanh", "arctan", "sqrt", "rem", "mod", "round"</param>
        /// <param name="loadPreDefinedOperators">This will load "%", "*", ":", "/", "+", "-", ">", "&lt;", "="</param>
        /// <param name="loadPreDefinedVariables">This will load "pi", "pi2", "pi05", "pi025", "pi0125", "pitograd", "piofgrad", "e", "phi", "major", "minor"</param>
        public MathParser(bool loadPreDefinedFunctions = true, bool loadPreDefinedOperators = true, bool loadPreDefinedVariables = true)
        {
            if (loadPreDefinedOperators)
            {
                // by default, we will load basic arithmetic operators.
                // please note, its possible to do it either inside the constructor, or outside the class.
                
                // THE LIST IS IN ORDER AND THE LOWEST OPERATOR WILL BE EXECUTED FIRST!
                OperatorList.Add("^"); // to the power of
                OperatorList.Add("%"); // modulo
                OperatorList.Add(":"); // division 1
                OperatorList.Add("/"); // division 2
                OperatorList.Add("*"); // multiplication
                OperatorList.Add("-"); // subtraction
                OperatorList.Add("+"); // addition

                OperatorList.Add(">"); // greater than
                OperatorList.Add("≥"); // greater or equal than
                OperatorList.Add("<"); // less than
                OperatorList.Add("≤"); // less or equal than
                OperatorList.Add("="); // are equal
                OperatorList.Add("≠"); // not equal

                // when an operator is executed, the parser needs to know how.
                // this is how you can add your own operators. note, the order
                // in this list does not matter.
                OperatorAction.Add("^", Math.Pow);
                OperatorAction.Add("%", (numberA, numberB) => numberA % numberB);
                OperatorAction.Add(":", (numberA, numberB) => numberA / numberB);
                OperatorAction.Add("/", (numberA, numberB) => numberA / numberB);
                OperatorAction.Add("*", (numberA, numberB) => numberA * numberB);
                OperatorAction.Add("+", (numberA, numberB) => numberA + numberB);
                OperatorAction.Add("-", (numberA, numberB) => numberA - numberB);

                OperatorAction.Add(">", (numberA, numberB) => numberA > numberB ? 1 : 0);
                OperatorAction.Add("≥", (numberA, numberB) => numberA >= numberB ? 1 : 0);
                OperatorAction.Add("<", (numberA, numberB) => numberA < numberB ? 1 : 0);
                OperatorAction.Add("≤", (numberA, numberB) => numberA <= numberB ? 1 : 0);
                OperatorAction.Add("=", (numberA, numberB) => Math.Abs(numberA - numberB) < double.Epsilon ? 1 : 0);
                OperatorAction.Add("≠", (numberA, numberB) => Math.Abs(numberA - numberB) < double.Epsilon ? 0 : 1);

            }


            if (loadPreDefinedFunctions)
            {
                // these are the basic functions you might be able to use.
                // as with operators, localFunctions might be adjusted, i.e.
                // you can add or remove a function.
                // please open the "MathosTest" project, and find MathParser.cs
                // in "CustomFunction" you will see three ways of adding 
                // a new function to this variable!
                // EACH FUNCTION MAY ONLY TAKE ONE PARAMETER, AND RETURN ONE
                // VALUE. THESE VALUES SHOULD BE IN "DOUBLE FORMAT"!
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

                LocalFunctions.Add("radtodeg", x => x[0] / Math.PI * 180.0);
                LocalFunctions.Add("degtorad", x => x[0] / 180.0 * Math.PI);

                LocalFunctions.Add("arctan2", x => Math.Atan2(x[0], x[1]));
                LocalFunctions.Add("atan2", x => Math.Atan2(x[0], x[1]));

                /* distance, projectdistance, projectheight
                 * 
                 * Using in-game coordination and direction defination:
                 * Given point A (x1, y1), point B (x2, y2) and a ray with direction θ1 starting from A.
                 * The project point of B on the ray direction is H.
                 * 
                 * distance = |AB|
                 * projectdistance = AH (directed distance, negative if H is on the other side)
                 * projectheight = |BH|
                 * AH² + BH² = AB²
                 * 
                 * Useful when doing calculations about line AoE.
                 */
                LocalFunctions.Add("distance", DistanceFunction);
                LocalFunctions.Add("d", DistanceFunction);
                LocalFunctions.Add("projectdistance", ProjectDistanceFunction);
                LocalFunctions.Add("projd", ProjectDistanceFunction);
                LocalFunctions.Add("projectheight", ProjectHeightFunction);
                LocalFunctions.Add("projh", ProjectHeightFunction);

                LocalFunctions.Add("angle", x => Math.Atan2(x[2] - x[0], x[3] - x[1]));
                LocalFunctions.Add("θ", x => Math.Atan2(x[2] - x[0], x[3] - x[1]));
                LocalFunctions.Add("relangle", x => ((x[1] - x[0]) % (2 * Math.PI) + (2 * Math.PI)) % (2 * Math.PI) - Math.PI);
                LocalFunctions.Add("relθ", x => ((x[1] - x[0]) % (2 * Math.PI) + (2 * Math.PI)) % (2 * Math.PI) - Math.PI);

                /* roundir, roundvec
                 * 
                 * Matches the given direction in radian (roundir) or as a vector dx, dy (roundvec)
                 * to the direction in a circle divided into 'n' segments, 
                 * and returns the index of the direction (rounded to the nth decimal digit).
                 * indexes: 0, 1, 2, ..., n-1, from north CCW.
                 */
                LocalFunctions.Add("roundir", RoundirFunction);
                LocalFunctions.Add("roundvec", RoundvecFunction);

                LocalFunctions.Add("random", x => RandomNumber(x[0], x[1]));

                LocalFunctions.Add("sqrt", x => Math.Sqrt(x[0]));
                LocalFunctions.Add("rem", x => Math.IEEERemainder(x[0], x[1]));
                LocalFunctions.Add("mod", x => (x[0] % x[1] + x[1]) % x[1]);
                LocalFunctions.Add("root", x => Math.Pow(x[0], 1.0 / x[1]));

                LocalFunctions.Add("pow", x => Math.Pow(x[0], x[1]));

                LocalFunctions.Add("exp", x => Math.Exp(x[0]));
                //LocalFunctions.Add("log", x => (decimal)Math.Log((double)x[0]));
                //LocalFunctions.Add("log10", x => (decimal)Math.Log10((double)x[0]));

                LocalFunctions.Add("log", delegate (double[] input)
                {
                    // input[0] is the number
                    // input[1] is the base

                    switch (input.Length)
                    {
                        case 1:
                            return Math.Log(input[0]);
                        case 2:
                            return Math.Log(input[0], input[1]);
                        default:
                            return 0; // false
                    }
                });

                LocalFunctions.Add("round", delegate (double[] input)
                {
                    // input[0] is the number
                    // input[1] is the decimals

                    switch (input.Length)
                    {
                        case 1:
                            return Math.Round(input[0]);
                        case 2:
                            return Math.Round(input[0], (int)input[1]);
                        default:
                            return 0; // false
                    }
                });

                LocalFunctions.Add("max", x =>
                {
                    double max = x[0];
                    for (int i = 1; i < x.Count(); i++)
                    {
                        max = Math.Max(x[i], max);
                    }
                    return max;
                });

                LocalFunctions.Add("min", x => {
                    double min = x[0];
                    for (int i = 1; i < x.Count(); i++)
                    {
                        min = Math.Min(x[i], min);
                    }
                    return min;
                });

                LocalFunctions.Add("truncate", x => x[0] < 0 ? -Math.Floor(-x[0]) : Math.Floor(x[0]));
                LocalFunctions.Add("floor", x => Math.Floor(x[0]));
                LocalFunctions.Add("ceiling", x => Math.Ceiling(x[0]));
                LocalFunctions.Add("sign", x => Math.Sign(x[0]));

                LocalFunctions.Add("or", x => OrFunction(x));
                LocalFunctions.Add("and", x => AndFunction(x));
                LocalFunctions.Add("if", x => IfFunction(x[0], x[1], x[2]));

                // Mathparser string function parameters only contain numbers, Unicode letters, #, _.
                // Otherwise, should use ${func:...} instead.

                LocalStringFunctions.Add("hex2dec", x => Hex2DecFunction(x));
                LocalStringFunctions.Add("hex2float", x => Hex2FloatFunction(x));
                LocalStringFunctions.Add("hex2double", x => Hex2DoubleFunction(x));
                LocalStringFunctions.Add("X8float", x => Hex2FloatFunction(x));
                LocalStringFunctions.Add("parsedmg", x => ParseDmgFunction(x));
                LocalStringFunctions.Add("len", x => x[0].Length);
                LocalStringFunctions.Add("freq", x => FreqFunction(x));
            }

            if (loadPreDefinedVariables)
            {
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
                LocalVariables.Add("ETmin2sec", 70.0 / 24.0);
                LocalVariables.Add("semitone", Math.Pow(2, 1.0 / 12));
                LocalVariables.Add("cent", Math.Pow(2, 1.0 / 1200));
            }
        }

        #region Properties

        /// <summary>
        /// All operators should be inside this property.
        /// The first operator is executed first, et cetera.
        /// An operator may only be ONE character.
        /// </summary>
        public List<string> OperatorList { get; set; } = new List<string>();

        /// <summary>
        /// When adding a variable in the OperatorList property, you need to assign how that operator should work.
        /// </summary>
        public Dictionary<string, Func<double, double, double>> OperatorAction { get; set; } =
            new Dictionary<string, Func<double, double, double>>();

        /// <summary>
        /// All functions that you want to define should be inside this property.
        /// </summary>
        public Dictionary<string, Func<double[], double>> LocalFunctions { get; set; } =
            new Dictionary<string, Func<double[], double>>();

        public Dictionary<string, Func<string[], double>> LocalStringFunctions { get; set; } =
            new Dictionary<string, Func<string[], double>>();

        /// <summary>
        /// All variables that you want to define should be inside this property.
        /// </summary>
        public Dictionary<string, double> LocalVariables { get; set; } = new Dictionary<string, double>();

        /// <summary>
        /// When converting the result from the Parse method or ProgrammaticallyParse method ToString(),
        /// please use this cultur info.
        /// </summary>
        public CultureInfo CultureInfo { get; } = CultureInfo.InvariantCulture;

        #endregion

        /// <summary>
        /// Enter the math expression in form of a string.
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <returns></returns>
        public double Parse(string mathExpression)
        {
            return MathParserLogic(Lexer(mathExpression));
        }

        /// <summary>
        /// Enter the math expression in form of a list of tokens.
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <returns></returns>
        public double Parse(ReadOnlyCollection<string> mathExpression)
        {
            return MathParserLogic(new List<string>(mathExpression));
        }

        /// <summary>
        /// Enter the math expression in form of a string. You might also add/edit variables using "let" keyword.
        /// For example, "let sampleVariable = 2+2".
        /// 
        /// Another way of adding/editing a variable is to type "varName := 20"
        /// 
        /// Last way of adding/editing a variable is to type "let varName be 20"
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <param name="correctExpression"></param>
        /// <param name="identifyComments"></param>
        /// <returns></returns>


        /* This part is currently not used in Triggernometry.
         
        public double ProgrammaticallyParse(string mathExpression, bool correctExpression = true, bool identifyComments = true)
        {
            if (identifyComments)
            {
                // Delete Comments #{Comment}#
                mathExpression = System.Text.RegularExpressions.Regex.Replace(mathExpression, "#\\{.*?\\}#", "");

                // Delete Comments #Comment
                mathExpression = System.Text.RegularExpressions.Regex.Replace(mathExpression, "#.*$", "");
            }

            if (correctExpression)
            {
                // this refers to the Correction function which will correct stuff like artn to arctan, etc.
                mathExpression = Correction(mathExpression);
            }

            string varName;
            double varValue;

            if (mathExpression.Contains("let"))
            {
                if (mathExpression.Contains("be"))
                {
                    varName = mathExpression.Substring(mathExpression.IndexOf("let", StringComparison.Ordinal) + 3,
                        mathExpression.IndexOf("be", StringComparison.Ordinal) -
                        mathExpression.IndexOf("let", StringComparison.Ordinal) - 3);
                    mathExpression = mathExpression.Replace(varName + "be", "");
                }
                else
                {
                    varName = mathExpression.Substring(mathExpression.IndexOf("let", StringComparison.Ordinal) + 3,
                        mathExpression.IndexOf("=", StringComparison.Ordinal) -
                        mathExpression.IndexOf("let", StringComparison.Ordinal) - 3);
                    mathExpression = mathExpression.Replace(varName + "=", "");
                }

                varName = varName.Replace(" ", "");
                mathExpression = mathExpression.Replace("let", "");

                varValue = Parse(mathExpression);

                if (LocalVariables.ContainsKey(varName))
                    LocalVariables[varName] = varValue;
                else
                    LocalVariables.Add(varName, varValue);

                return varValue;
            }

            if (!mathExpression.Contains(":="))
                return Parse(mathExpression);

            //mathExpression = mathExpression.Replace(" ", ""); // remove white space
            varName = mathExpression.Substring(0, mathExpression.IndexOf(":=", StringComparison.Ordinal));
            mathExpression = mathExpression.Replace(varName + ":=", "");

            varValue = Parse(mathExpression);
            varName = varName.Replace(" ", "");

            if (LocalVariables.ContainsKey(varName))
                LocalVariables[varName] = varValue;
            else
                LocalVariables.Add(varName, varValue);

            return varValue;
        }
        */

        /// <summary>
        /// This will convert a string expression into a list of tokens that can be later executed by Parse or ProgrammaticallyParse methods.
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <returns>A ReadOnlyCollection</returns>
        public ReadOnlyCollection<string> GetTokens(string mathExpression)
        {
            return Lexer(mathExpression).AsReadOnly();
        }

        #region Core

        /// <summary>
        /// This will correct sqrt() and arctan() written in different ways only.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        /* This part is currently not used in Triggernometry.
        
        private string Correction(string input)
        {
            // Word corrections

            input = System.Text.RegularExpressions.Regex.Replace(input, "\\b(sqr|sqrt)\\b", "sqrt",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            input = System.Text.RegularExpressions.Regex.Replace(input, "\\b(atan2|arctan2)\\b", "arctan2",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //... and more

            return input;
        }
        */

        /// <summary>
        /// Tokenizes <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The expression.</param>
        /// <returns>Tokens found <paramref name="expr"/>.</returns>

        bool IsValidAlphaNum(char c)
        {
            return char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '#';
        }

        private List<string> Lexer(string expr)
        {
            var token = "";
            var tokens = new List<string>();

            // delete all spaces to avoid the splitting error of +/- when parsing strings like "1 + -1".
            expr = expr.Replace(" ", "");

            // replace continuous +/- to a single +/- base on the count of "-"
            expr = Regex.Replace(expr, @"[-+]{2,}", match => match.Value.Replace("+", "").Length % 2 == 0 ? "+" : "-");

            for (var i = 0; i < expr.Length; i++)
            {
                var ch = expr[i];

                if (char.IsLetter(ch) && ch != '_')
                {
                    if (i != 0 && (char.IsDigit(expr[i - 1]) || expr[i - 1] == ')'))
                    {
                        tokens.Add("*");
                    }

                    token += ch;

                    while (i + 1 < expr.Length && IsValidAlphaNum(expr[i + 1]))
                        token += expr[++i];

                    tokens.Add(token);
                    token = "";
                }
                else if (char.IsDigit(ch))
                {
                    token += ch;

                    while (i + 1 < expr.Length && IsValidAlphaNum(expr[i + 1]))
                        token += expr[++i];

                    tokens.Add(token);
                    token = "";
                }

                else if (ch == '(')
                {
                    // add a "*" if the previous char is letter / digit / ")" and the previous token is not a function.
                    if (i != 0 
                        && (char.IsLetterOrDigit(expr[i - 1]) || expr[i - 1] == ')')
                        && tokens.Count > 0
                        && !LocalFunctions.ContainsKey(tokens[tokens.Count - 1])
                        && !LocalStringFunctions.ContainsKey(tokens[tokens.Count - 1])
                        )
                        tokens.Add("*");
                    
                    tokens.Add("(");
                }
                else
                    tokens.Add(ch.ToString());
            }
            return tokens;
        }

        private double MathParserLogic(List<string> tokens)
        {
            // Variables replacement
            for (var i = 0; i < tokens.Count; i++)
            {
                if (LocalVariables.Keys.Contains(tokens[i]))
                    tokens[i] = LocalVariables[tokens[i]].ToString(CultureInfo);
            }

            while (tokens.IndexOf("(") != -1)
            {
                // getting data between "(" and ")"
                var open = tokens.LastIndexOf("(");
                var close = tokens.IndexOf(")", open); // in case open is -1, i.e. no "(" // , open == 0 ? 0 : open - 1

                if (open >= close)
                    throw new ArithmeticException(I18n.Translate("internal/MathParser/noclosure", "No closing bracket/parenthesis. Token: {0}", open.ToString(CultureInfo)));

                var roughExpr = new List<string>();

                for (var i = open + 1; i < close; i++)
                    roughExpr.Add(tokens[i]);

                double tmpResult;

                var args = new List<double>();
                var sargs = new List<string>();
                var functionName = tokens[open == 0 ? 0 : open - 1];

                if (LocalFunctions.Keys.Contains(functionName))
                {
                    if (roughExpr.Contains(","))
                    {
                        // converting all arguments into a decimal array
                        for (var i = 0; i < roughExpr.Count; i++)
                        {
                            var defaultExpr = new List<string>();
                            var firstCommaOrEndOfExpression = (roughExpr.IndexOf(",", i) != -1)
                                ? roughExpr.IndexOf(",", i)
                                : roughExpr.Count;

                            while (i < firstCommaOrEndOfExpression)
                                defaultExpr.Add(roughExpr[i++]);

                            args.Add(defaultExpr.Count == 0 ? 0 : BasicArithmeticalExpression(defaultExpr));
                        }

                        // finally, passing the arguments to the given function
                        tmpResult = double.Parse(LocalFunctions[functionName](args.ToArray()).ToString(CultureInfo), CultureInfo);
                    }
                    else
                    {
                        // but if we only have one argument, then we pass it directly to the function
                        tmpResult =
                            double.Parse(
                                LocalFunctions[functionName](new[] { BasicArithmeticalExpression(roughExpr) })
                                    .ToString(CultureInfo), CultureInfo);
                    }
                }
                else if (LocalStringFunctions.Keys.Contains(functionName))
                {
                    if (roughExpr.Contains(","))
                    {
                        // converting all arguments into a decimal array
                        for (var i = 0; i < roughExpr.Count; i++)
                        {
                            var defaultExpr = new List<string>();
                            var firstCommaOrEndOfExpression = (roughExpr.IndexOf(",", i) != -1)
                                ? roughExpr.IndexOf(",", i)
                                : roughExpr.Count;

                            while (i < firstCommaOrEndOfExpression)
                                defaultExpr.Add(roughExpr[i++]);
                            string argExpr = string.Join("", defaultExpr);
                            sargs.Add(defaultExpr.Count == 0 ? "0" : argExpr);
                        }

                        // finally, passing the arguments to the given function
                        tmpResult = double.Parse(LocalStringFunctions[functionName](sargs.ToArray()).ToString(CultureInfo), CultureInfo);
                    }
                    else
                    {
                        // but if we only have one argument, then we pass it directly to the function
                        tmpResult =
                            double.Parse(
                                LocalStringFunctions[functionName](new[] { roughExpr[0] })
                                    .ToString(CultureInfo), CultureInfo);
                    }
                }
                else
                {
                    // if no function is need to execute following expression, pass it
                    // to the "BasicArithmeticalExpression" method.
                    tmpResult = BasicArithmeticalExpression(roughExpr);
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
            return BasicArithmeticalExpression(tokens);
        }
        
        private double BasicArithmeticalExpression(List<string> tokens)
        {
            // PERFORMING A BASIC ARITHMETICAL EXPRESSION CALCULATION
            // THIS METHOD CAN ONLY OPERATE WITH NUMBERS AND OPERATORS
            // AND WILL NOT UNDERSTAND ANYTHING BEYOND THAT.

            switch (tokens.Count)
            {
                case 0:
                    return 0;
                case 1:
                    return double.Parse(tokens[0], CultureInfo);
                case 2:
                    var op = tokens[0];
                    return OperatorAction[op](0, double.Parse(tokens[1], CultureInfo));
            }

            foreach (var op in OperatorList)
            {
                while (tokens.IndexOf(op) != -1)
                {
                    var opPlace = tokens.IndexOf(op);

                    if ((op == "+" || op == "-") && (opPlace == 0 || OperatorList.Contains(tokens[opPlace - 1])))
                    {   // e.g. '0 = -sin(0)' => '0' '=', '-', '0',
                        // need to insert a "0" when parsing "+" "-"
                        tokens.Insert(opPlace, "0");
                        opPlace++;
                    }
                    if ((tokens[opPlace + 1] == "+" || tokens[opPlace + 1] == "-"))
                    {   // e.g. '1 * -sin(0)' => '1' '*', '-', '0',
                        // need to combine "-" and the next digit when parsing "*", "^", ...
                        double combined = double.Parse(tokens[opPlace + 1] + "1") * double.Parse(tokens[opPlace + 2]);
                        tokens[opPlace + 2] = combined.ToString(CultureInfo);
                        tokens.RemoveAt(opPlace + 1);
                    }

                    var numberA = double.Parse(tokens[opPlace - 1], CultureInfo);
                    var numberB = double.Parse(tokens[opPlace + 1], CultureInfo);

                    var result = OperatorAction[op](numberA, numberB);

                    tokens[opPlace - 1] = result.ToString(CultureInfo);
                    tokens.RemoveRange(opPlace, 2);
                }
            }

            return double.Parse(tokens[0], CultureInfo);
        }

        #endregion
    }

}
