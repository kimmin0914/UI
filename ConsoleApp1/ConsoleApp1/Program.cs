using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        class Product
        {
            public string name;
            public int price;

            public void Print()
            {
                Console.WriteLine(name + " : " + price + "원");
            }
        }

        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Product potato = new Product();
            potato.name = "감자";
            potato.price = 2000;

            Product tomato = new Product();
            tomato.name = "토마토";
            tomato.price = 3000;
            list.Add(potato);
            list.Add(tomato);

            foreach (var item in list)
            {
                //Console.WriteLine(item.name + " : " + item.price + "원");
                item.Print();
            }
        }

    }
}
    
    //class Program
    //{

    //    class Product
    //    {
    //        public string name;
    //        public int price;
    //    }

    //    static void Main(string[] args)
    //    {
    //        Product product = new Product();
    //        product.name = "감자";
    //        product.price = 3000;

    //        Console.WriteLine(product.name + " : " + product.price + "원");
    //    }
    //}



    //class FirstClass {  }
    //class SecondClass {  }
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        FirstClass myClass = new FirstClass();
    //        SecondClass myClass2 = new SecondClass();
    //        ThirdClass myClass3 = new ThirdClass();


            /*int time = 10;
            Console.WriteLine((9 < time) && (time < 12));
            Console.WriteLine(DateTime.Now.Hour > 9 || DateTime.Now.Hour < 12);
            Console.WriteLine(DateTime.Now.Hour > 9 && DateTime.Now.Hour < 12);
            Console.WriteLine(int.MaxValue);//2147483647
            Console.WriteLine(int.MinValue);//-2147483648
            Console.WriteLine(long.MaxValue);// 9223372036854775807
            Console.WriteLine(long.MinValue);// -9223372036854775808

            // 자료형의 크기를 나타내는 명령어 sizeof @
            Console.WriteLine("int: " + sizeof(int));// 4
            Console.WriteLine("long: " + sizeof(long));// 8
            Console.WriteLine("float: " + sizeof(float));// 4
            Console.WriteLine("double: " + sizeof(double));// 8
            Console.WriteLine("char: " + sizeof(char));// 2*/
            /*char a = 'a';
            char b = 'b';

            Console.WriteLine(a + b);// 195
            Console.WriteLine(a - b);// -1
            Console.WriteLine(a * b);// 9506
            Console.WriteLine(a / b);// 0
            Console.WriteLine(a % b);// 97
            Console.WriteLine(('A' + 1L));// 66*/

            /* string abc = "Hello";

             Console.WriteLine(sizeof(bool));// 1*/

            /* //후 입력
             int number = 10;
             Console.WriteLine(number);// 10
             Console.WriteLine(number++);// 10
             Console.WriteLine(number--);// 11
             Console.WriteLine(number);// 10

             //선 입력
             Console.WriteLine(number);// 10
             Console.WriteLine(++number);// 11
             Console.WriteLine(--number);// 10
             Console.WriteLine(number);// 10*/

            /* // 콘솔창에 채팅 가능 계산기
             Console.Write("입력1 : "); // 100 200 123
             string num1 = Console.ReadLine();
             Console.Write("입력2 : ");
             string num2 = Console.ReadLine();
             Console.WriteLine(int.Parse(num1) + int.Parse(num2));*/

            /*// long 자료형을 int 자료형으로 변환. 작은거 (int)--> 큰거 (long) 가능 반대는 불가능.
            long longNumber = 2147483647L + 2147483647L;
            int intNumber = longNumber;*/

            /*// string + 숫자는 불가능하여 5252로 나옴
            Console.WriteLine(52 + "" + 52);// 5252*/

            /*    // 소수점 제거 F1 = 0.0이랑 같은 의미 다른 표현 방법
                double number = 52.273103;
                Console.WriteLine(number. ToString("F1"));// 52.3
                Console.WriteLine(number.ToString("F2"));// 52.27
                Console.WriteLine(number.ToString("0.000"));// 52.273
                Console.WriteLine(number.ToString("0.0000"));// 52.2731*/

            /*//음수밖에 없는 숫자
            int output = int.MinValue;
            Console.WriteLine(-output); // -2147483648*/

            // 가독성이 좋게 만든 계산기
            /*            Console.Write("입력1 : ");
                        string num1 = Console.ReadLine();
                        Console.Write("입력2 : ");
                        string num2 = Console.ReadLine();
                        Console.WriteLine(num1 + "+" + num2 + "=" +(int.Parse(num1) + int.Parse(num2)));
                        Console.WriteLine(num1 + "-" + num2 + "=" +(int.Parse(num1) - int.Parse(num2)));
                        Console.WriteLine(num1 + "*" + num2 + "=" +(int.Parse(num1) * int.Parse(num2)));
                        Console.WriteLine(num1 + "%" + num2 + "=" +(int.Parse(num1) / int.Parse(num2)));*/

            /*            if (DateTime.Now.Hour < 11)
                        {
                            Console.WriteLine("아침 먹을 시간 입니다.");
                        }
                        else if (DateTime.Now.Hour < 15)
                        {
                            Console.WriteLine("점심 먹을 시간 입니다.");
                        }
                        else
                        {
                            Console.WriteLine("저녁 먹을 시간 입니다.");
                        }*/

            /*            Console.WriteLine("숫자를 입력하세요 :");

                        string s_input = Console.ReadLine();
                        int input = int.Parse(s_input);
                        int remain = input % 2;*/

            /*            //조건문
                        switch (remain)
                        {
                            case 0:
                                Console.WriteLine("짝수입니다.");
                                break;
                            case 1:
                                Console.WriteLine("홀수입니다.");
                                break;*/
            /*                    if (remain == 0)
                        {
                            Console.WriteLine("짝수입니다.");
                        }
                        else if (remain == 1)
                        {
                            Console.WriteLine("홀수입니다.");
                        }*/

            /*            Console.WriteLine("이번 달은 몇 월 인가요 : ");

                        int input = int.Parse(Console.ReadLine());

                        switch(input)
                        {
                            case 12:
                            case 1:
                            case 2:
                                Console.WriteLine("겨울입니다.");
                                break;
                            case 3:
                            case 4:
                            case 5:
                                Console.WriteLine("봄입니다.");
                                break;
                            case 6:
                            case 7:
                            case 8:
                                Console.WriteLine("여름입니다.");
                                break;
                            case 9:
                            case 10:
                            case 11:
                                Console.WriteLine("가을입니다.");
                                break;
                            default:
                                Console.WriteLine("대체 어떤 행성에 살고 계신가요?");
                                break;
                        }*/

            /*            Console.WriteLine("이번 달은 몇 월 인가요? : ");

                        int input = int.Parse(Console.ReadLine());

                        if (input == 12 || (input > 0 && input < 3))
                        {
                            Console.WriteLine("겨울입니다.");
                        }
                        else if (input < 6)
                        {
                            Console.WriteLine("봄입니다");
                        }
                        else if (input < 9)
                        {
                            Console.WriteLine("여름입니다.");
                        }
                        else if (input < 12)
                        {
                            Console.WriteLine("가을입니다.");
                        }*/

            /*            Console.WriteLine("입력 : ");
                        string line = Console.ReadLine();
                        if (line.Contains("안녕"))
                        {
                            Console.WriteLine("안녕하세요...!");
                        }
                        else
                        {
                            Console.WriteLine("^^");
                        }*/

            /*            for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine("출력");
                        }*/

            /*            int[] intArray = { 52, 273, 32, 65, 103 };
                        Console.WriteLine(intArray[0]);
                        Console.WriteLine(intArray[1]);
                        Console.WriteLine(intArray[2]);
                        Console.WriteLine(intArray[3]);
                        Console.WriteLine(intArray[4]);*/

            /*            int[] intArray = { 52, 273, 32, 65, 103};
                        for (int i = 0; i < intArray.Length; i++)
                            Console.WriteLine(intArray[i]);*/

            /*            int[] array = new int[100];
                        for(int i = 0; i < array.Length; i++)
                        {
                            array[i] = i;
                        }
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.WriteLine(array[i]);
                        }*/

            /*            int[] intArray = { 52, 273, 32, 65, 103 };
                        int cnt = 0;

                        while(cnt < intArray.Length)
                        {
                            Console.WriteLine(cnt + "번째 출력 : " + intArray[cnt]);
                            cnt++;
                        }*/

            //string[] array = { "사과", "배", "포도", "딸기", "바나나" };

            //foreach (string item  in array)
            //{
            //    Console.WriteLine(item);
            //}

            //string[] array = { "사과", "배", "포도", "딸기", "바나나" };

            //foreach (var item in  array)
            //{
            //    Console.WriteLine(item);    
            //}

            //while(true)
            //{
            //    Console.WriteLine("숫자 입력(짝수입력시 종료): ");
            //    int input = int.Parse(Console.ReadLine());
            //    if(input % 2 == 0)
            //    {
            //        break;
            //    }
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    if( i % 2 == 0)
            //    {
            //        continue;
            //    }

            //    Console.WriteLine(i); // break는 반복을 그만 두는 것 continue는 현재 반복을 멈추고 다음 반복을 진행
            //}

            //string input = "Potato Tomato";
            //Console.WriteLine(input.ToUpper());
            //Console.WriteLine(input.ToLower());

            //Console.WriteLine(input);

            //string input = "감자 고구마 토마토";
            //string[] output = input.Split(' ');

            //for (int i = 0; i < output.Length; i++)
            //{
            //    Console.WriteLine(output[i]);
            //}

            //string[] array = { "감자", "고구마", "토마토" };
            //Console.WriteLine(string.Join("----", array));

            //string[] array = { "감자", "고구마", "토마토" };

            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //    Thread.Sleep(1000);
            //}

            //bool state = true;

            //while(state)
            //{
            //    ConsoleKeyInfo info = Console.ReadKey();
            //    switch(info.Key)
            //    {
            //        case ConsoleKey.UpArrow:
            //            Console.WriteLine("위로");
            //            break;
            //        case ConsoleKey.RightArrow:
            //            Console.WriteLine("우로");
            //            break;
            //        case ConsoleKey.LeftArrow:
            //            Console.WriteLine("좌로");
            //            break;
            //        case ConsoleKey.DownArrow:
            //            Console.WriteLine("아래로");
            //            break;
            //        case ConsoleKey.X:
            //            state = false;
            //            break;

            //    }    
            //}

            //Random random = new Random();
            //Random random2 = new Random();

            //Console.WriteLine(random.Next());
            //Console.WriteLine(random2.Next());
            //Console.WriteLine(random.Next(100));
            //Console.WriteLine(random.Next(20,100));

            //로또 번호 추천 1 - 45 5개 중복 허용
            //Random random = new Random();

            //for (int i = 0; i < 6; i ++)
            //{
            //    Console.WriteLine(random.Next(1, 46));
            //}

            //int j = 0;
            //while (j < 6)
            //{
            //    Console.WriteLine(random.Next(1, 46));
            //    j++;
            //}
            //Random random = new Random();

            //for (int i = 0; i < 6; i++)
            //{
            //    Console.WriteLine(random.NextDouble() * 10);
            //}
            //Random random = new Random();

            //for (int i = 0; i < 6; i++)
            //{
            //    double num2 = random.NextDouble();
            //    int num = random.Next(0, 10);
            //    Console.WriteLine(num+num2);
            //    Console.WriteLine(random.NextDouble() * 10);
            //}

            //List<int> list = new List<int>();

            //list.Add(52);
            //list.Add(52);
            //list.Add(273);
            //list.Add(32);
            //list.Add(64);

            //list.RemoveAt(0);
            //list.Remove(52);
            //foreach (var item in list)
            //{
            //    Console.WriteLine("Count:" + list.Count + "\t Item: " + item);
            //}

            //List<int> list = new List<int>();

            //list.Add(52);
            //list.Add(273);
            //list.Add(32);
            //list.Add(64);
            //Random rnd = new Random();

            //for (int i = 0; i < 100; i++)
            //{
            //    list.Add(rnd.Next(500));
            //    list.RemoveAt(0);
            //    Console.WriteLine("Count:" + list.Count + "\t Item: " + list[0]);
            //}

    //    }
    //}

