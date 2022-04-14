
<!-- @import "[TOC]" {cmd="toc" depthFrom=1 depthTo=6 orderedList=false} -->

<!-- code_chunk_output -->

- [基础语法](#基础语法)
  - [1. 占位符](#1-占位符)
  - [2. 转义符](#2-转义符)
  - [3. Convert (Cast)](#3-convert-cast)
- [复杂数据类型](#复杂数据类型)
  - [Enum](#enum)
  - [struct](#struct)
  - [数组](#数组)
  - [方法](#方法)
- [函数 method](#函数-method)
  - [out 参数](#out-参数)
  - [ref 参数](#ref-参数)
  - [params 参数](#params-参数)
  - [Overload vs. Override](#overload-vs-override)

<!-- /code_chunk_output -->

# 基础语法
## 1. 占位符
- `$` 使占位符 evaluate 括号内的内容
``` cs
Console.WriteLine("What is your name?");
var name = Console.ReadLine();
var currentDate = DateTime.Now;
Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);
```

## 2. 转义符
- `\b`: 表示一个退格键，放到字符串的两边没有效果
- `@`: 
  - 取消`\`在 `string` 的转义作用，使其单纯的表示为一个`\`
  - `string` 按照编辑的原格式输出


## 3. Convert (Cast)
- `Conver.ToInt32()` 
- `Convert.ToDouble()`
  
# 复杂数据类型
## Enum
- 语法
  ``` csharp
  [public] enum Name {
      Type1 = 1, 
      Type2,
      Type3
  }
  ```
- Enum can start with value 1, default is 0
- string get enum type
  - `(Name) Enum.Parse(typeof(Name), "s")`
  
## struct
- 一次性声明多个不同类型的变量
- 语法
  ```cs
  [public] struct Name {
      成员;
  }
  ```
  
## 数组
- 语法
  ``` cs
  数组类型[] name =  new 数组类型[数组长度]
  int[] nums = {1, 2, 3, 4, 5, 6, 7, 8};
  // 以下不推荐
  int[] nums = new int[3] {1, 2, 3};
  int[] nums = new int[] {1, 2, 3};
  ```
- 长度固定后，不能改变
- 排序 `Array.sort()`

## 方法
```cs
[public] static return name([parameters]) {
  
}
```



# 函数 method
## out 参数
- 可以 return 多个不同类型的 value
- function call 前先initialize, pass as parameters, 然后在 method 里面 assign

## ref 参数
- reference，直接改变

## params 参数
- 可变参数
- 把 element 处理为数组的元素

## Overload vs. Override
- Overload: 相同名字，不同参数