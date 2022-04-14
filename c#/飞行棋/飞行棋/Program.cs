/// See https://aka.ms/new-console-template for more information
using static J3QQ4.Emoji;

class 飞行棋
{
    public static int[] maps = new int[100];

    //声明一个静态数组来存储玩家A和玩家B的坐标
    static int[] PlayerPos = new int[2];

    static string[] playerNames = new string[2];

    public static void Main(string[] args)
    {
        GameShow();
        #region 输入玩家姓名
        Console.WriteLine("请输入玩家A的姓名");
        playerNames[0] = Console.ReadLine();
        while (playerNames[0] == "")
        {
            Console.WriteLine("玩家A的姓名不能为空，请重新输入");
            playerNames[0] = Console.ReadLine();

        }

        Console.WriteLine("请输入玩家B的姓名");
        playerNames[1] = Console.ReadLine();
        while (playerNames[1] == "" || playerNames[1] == playerNames[0])
        {
            if (playerNames[1] == "")
            {
                Console.WriteLine("玩家B的姓名不能为空，请重新输入");

            }
            else
            {
                Console.WriteLine("玩家B的姓名不能与玩家A的姓名相同，请重新输入");
            }
            playerNames[1] = Console.ReadLine();
        }

        #endregion

        // 玩家姓名输入后，首先清屏
        Console.Clear();
        GameShow();
        Console.WriteLine("{0}的士兵用A表示", playerNames[0]);
        Console.WriteLine("{0}的士兵用A表示", playerNames[1]);

        // 画地图前，先初始化地图
        InitialMap();
        DrawMap();


        // 当玩家A跟玩家B没有一个人在终点的时候，两个玩家不停的玩游戏
        while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
        {
            Console.WriteLine("{0}按任意键开始掷骰子", playerNames[0]);
            Console.ReadKey(true);

            Console.WriteLine("{0}掷除了{1}", playerNames[0], 0);
            PlayerPos[0] += 4;
            Console.ReadKey();
            Console.WriteLine("{0}按任意键开始行动", playerNames[0]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了", playerNames[0]);
            Console.ReadKey(true);

            Console.WriteLine("{0}猜到了方块，什么都不发生", playerNames[0]);

            //玩家a猜到了玩家b, 方块，幸运转盘，地雷，暂停，时空隧道
            if (PlayerPos[0] == PlayerPos[1])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}退6格", playerNames[0], playerNames[1], playerNames[1]);
                PlayerPos[1] -= 6;
                Console.ReadKey(true);
            }
            else
            {
                switch (maps[PlayerPos[0]])
                {
                    case 0: Console.WriteLine("play{0} steps on square, safe", playerNames[0]);
                        Console.ReadKey(true);
                        break;
                    case 1:Console.WriteLine("play{0} steps on 幸运转盘, 请选择 1 -- 交换位置，2 -- 轰炸对方", playerNames[0]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}选择跟玩家{1}交换位置", playerNames[0], playerNames[1]);
                                Console.ReadKey(true);
                                int temp = PlayerPos[0];
                                PlayerPos[0] = PlayerPos[1];
                                PlayerPos[1] = temp;
                                Console.WriteLine("交换完成！按任意键继续");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1}，玩家{2}退6格", playerNames[0], playerNames[1], playerNames[1]);
                                Console.ReadKey(true);
                                PlayerPos[1] -= 6;
                                Console.WriteLine("玩家{0}退了6格", playerNames[1]);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("输入invalid! 1 -- 交换位置 2 -- 轰炸对方");
                                Console.ReadKey(true);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("play{0} steps on 地雷，退6格", playerNames[0]);
                        Console.ReadKey(true);
                        PlayerPos[0] -= 6;
                        break;
                    case 3:
                        Console.WriteLine("play{0} steps on 暂停，暂停一回合", playerNames[0]);
                        break;
                    case 4:
                        Console.WriteLine("play{0} steps on 时空隧道，前进10格", playerNames[0]);
                        PlayerPos[0] += 10;
                        Console.ReadKey(true);
                        break;
                } // switch
                 
            } // else
            Console.Clear();
            DrawMap();

        } // while

    }

    /// <summary>
    /// 游戏头
    /// </summary>
    public static void GameShow()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("*******************************");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("*******************************");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*************飞行棋*************");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("*******************************");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("*******************************");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("*******************************"); 

    }

    /// <summary>
    /// 设置地图
    /// </summary>
    public static void InitialMap()
    {
        int[] luckyTurn = { 6, 23, 40, 55, 69, 83 };

        foreach (int i in luckyTurn)
        {
            maps[i] = 1;
        }


        int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
        foreach (int i in landMine)
        {
            maps[i] = 2;
        }

        int[] pause = { 9, 27, 60, 93 };
        foreach (int i in pause)
        {
            maps[i] = 3;
        }

        int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };
        foreach (int i in timeTunnel)
        {
            maps[i] = 4;
        }
    }

    /// <summary>
    /// 画地图
    /// </summary>
    public static void DrawMap()
    {

        Console.WriteLine("图例:幸运轮盘:◎   地雷:☆   暂停:▲   时空隧道:卐");
        #region first row
        for (int i = 0; i < 30; i++)
        {
            Console.Write(TestCase(i));
        } // for
        Console.WriteLine();
        #endregion

        #region right col
        for (int i = 30; i< 35; i++)
        {
            for (int j = 0; j < 29; j++)
            {
                Console.Write(" ");
            }

            Console.Write(TestCase(i));
            Console.WriteLine();

        }
        #endregion

        #region second row
        for (int i = 64; i >= 35; i--)
        {
            Console.Write(TestCase(i));
        } // for
        Console.WriteLine();
        #endregion

        #region left col
        for (int i = 65; i <= 69; i++)
        {
            Console.WriteLine(TestCase(i));
        } // for
        #endregion

        #region first row
        for (int i = 70; i < 100; i++)
        {
            Console.Write(TestCase(i));
        } // for
        Console.WriteLine();
        #endregion

    }

    /// <summary>
    /// Test cases
    /// </summary>
    /// <param name="i"> index </param>
    /// <returns> str </returns>
    public static string TestCase(int i)
    {
        string str = "";

        if (PlayerPos[0] == PlayerPos[1] && PlayerPos[1] == i)
        {
            str = "T";
        }
        else if (PlayerPos[0] == i)
        {
            str = "A";
        }
        else if (PlayerPos[1] == i)
        {
            str = "B";
        }
        else
        {   
            switch (maps[i])
            {
                case 0: 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    str = "_";
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    str = ":";
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    str = "x";
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    str = "o";
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    str = "s";
                    break;
            } // switch
        } // else

        return str;
    }
}
