# 第三章 基本概念
　　1、ECMAScript（对实现ECMA-262标准规定的各个方面内容的语言的描述。）的语法大量借鉴了C及其他类C语言（如Java和Perl）的语法。  
　　2、ECMAScript中的一切（变量、函数名和操作符）都区分大小写。  
　　3、标识符：变量、函数、属性的名字，或者函数的参数。第一个字符必须是一个字母、下划线（_）或一个美元符号（$），其他字符可以是字母、下划线、美元符号或数字。按照惯例其采用驼峰大小写格式myCar。不能把关键字、保留字、true、false、null用作标识符。  
　　4、ECMAScript使用C风格的注释，单行注释和块级别注释。块级注释中中间的星号不必须，只是为了提高注释的可读性。  
```
// 单行注释
/*
 * 这是一个
 * 多行（块级）注释
 */
```
　　5、ECMAScript5引入了严格模式（strict mode），为JavaScript定义了一种不同的解析与执行模式。在该模式下，ECMAScript3中的不确定行为将得到处理，某些不安全行为的操作会抛出错误，且不破坏ECMAScript3语法。下面严格模式的语句是一个编译指示，告诉JavaScript引擎切换到严格模式。支持严格模式的浏览器：IE10+、Firefox4+、Safari5.1+、Opera12+和Chrome。  
```
//在整个脚本中启用严格模式，在顶部添加代码
"user strict";
//指定函数在严格模式下执行
function doSomething() {
    "use strict";
    //函数体
}
```
　　6、关键字：ECMA-262描述的具有特定用途的字符，可用于表示控制语句的开始或结束，或用于执行特定操作等。关键字是语言保留的，不能用作标识符。  
break    do    instanceof   typeof    case    lese    new    var    catch    finally    return    void    continue    for    switch    while    debugger    function    this    with    default    if    throw    delete    in    try
　　7、保留字：ECMA-262描述的另一组不能用作标识符的字符，目前没有特殊用途，但可能会在将来被用作关键字。  
　　ECMA-262第3版：  
abstract    enum    int    short    boolean    export    interface    static    byte    extends    long    super    char    final    native    synchronized    class    float    package    throws    const    goto    private    transient    debugger    implements    protected    volatile    double    import    public  
　　第5版非严格模式下只有：  
class    enum    extends    super    const    export    import  
　　第5版严格模式下还有：  
implements    package    public    interface    private    static    let    protected    yield    (eval    arguments)  
　　8、ECMAScript的变量是松散类型的，即可以用来保存任何类型的数据，也即每个变量仅仅是一个用于保存值的占位符而已。  
```
var a //没有分号，有效但不推荐

var a; //未初始化，保存值为undefined

var b = "b"; //不会把变量标记为字符串类型，就是给变量赋一个值而已
b = 100; //改变变量保存值的类型，有效但不推荐

function test() {
    var c = "c"; //局部变量
    d = "d"; //全局变量
}
test();
alert(c); //错误，局部变量在函数退出后被销毁
alert(d); //"d" ，省略var创建全局变量，但不推荐，严格模式下抛出ReferenceError错误

var e = "e";
    f = "f"; //初始化两个变量
```
　　9、ECMAScript有5种简单数据类型（基本数据类型）：Undefined、Null、Boolean、Number、String。1种复杂数据类型：Object，它本质上是由一组无序的名值对组成的。不支持创建自定义类型的机制。数据类型具有动态性。  
　　10、ECMAScript的语法大量借鉴了C及其他类C语言（如Java和Perl）的语法。  
　　11、typeof操作符：检测给定变量的数据类型。  
被操作值 | 返回值
---- | ----
未定义 | "undefined"
布尔值 | "boolean"
字符串 | "string"
数值 | "number"
对象或null | "object"
函数 | "function"
```
var message = "message";
alert(typeof message); //"string"
alert(typeof(message)); //"string"
alert(typeof 95); //"number"
```

　　12、ECMAScript的语法大量借鉴了C及其他类C语言（如Java和Perl）的语法。  

**思考：**  
　　1、typeof和instanceof  
```

```
　　2、lese：。  
　　3、debugger：。  
　　1、with：。  
　　1、throw：。  
　　1、delete：。  
　　1、in：。  
　　1、 在第7点中的很多保留字已经被使用了。例如ES6中定义了类class。  