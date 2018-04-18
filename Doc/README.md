# Zoe-Language
一个脚本语言

## 语言特性

* 无类型

* 多返回值

* 面向对象类支持, 无构造函数系统

* 包支持

* 通用的词法分析器

* 抽象语法树

* 抽象虚拟机及指令

## 代码样板

```
    // 函数定义
    func Add(x, y){
        return x + y
    }

    func Foo(a, b){
        return Add(a, b)
    }

    // 函数调用
    var a = Foo(1, 2)

    // 循环
    var v=10
    for i=0; i<5; i=i+1{
        v = v - 1
    }

    // 包支持 
    import "ActorPackage"
    // 面向对象支持
    var actor = ActorPackage.GenerateActor()


    // 类型定义
    class Shape{
        type
    }

    func Shape.foo(self){
        self.type = "Shape"
    }
    
    func Shape.draw(self){
        
    }
    
    class Rectangle : Shape{
    }
    
    func Rectangle.foo(self){
        self.type = "Rectangle"
    }

    func Rectangle.draw(self){
        
    }
    
    
    var rect = new(Rectangle)
    
    rect.foo()
    rect.draw()
    
    // array支持
    var arr = []
    arr.Add(1)
    arr[0] = 1
     
    var x = arr[0]
    var g = arr.Get(0)
    arr.Set(0, "hello")
    var count = arr.Count
    var v, ok = arr.TryGet(119)
    
    // map支持
    var newBee = {
        1 : 12345,
        "hello": "world",
    }
```
