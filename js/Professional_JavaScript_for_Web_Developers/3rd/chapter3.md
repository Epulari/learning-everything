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
alert(typeof null); //特殊值null被认为是一个空的引用对象
```
　　typeof是操作符，因此上面例子中的圆括号可以使用，但不是必需。  
　　注意：Safari5及之前的版本、Chrome7及之前的版本在对正则表达式调用typeof操作符时会返回"function"，而其他浏览器在这种情况下会返回"object"。  
　　12、Undefined和Null类型：这两个数据类型各自都只有一个值，前者是undefined，后者是null。  
　　在定义变量但还未真正赋值时，最好明确地让变量保存null值，这样不仅可以体现null 作为空对象指针的惯例，而且也有助于进一步区分null和undefined。  
```
var a; //声明变量a但未定义，默认赋值为undefined
// var b; //未声明变量b
alert(a); //"undefined"
alert(b); //报错
alert(typeof a); //"undefined"
alert(typeof b); //"undefined"

var c = null;
alert(typeof c); //"object"
if(c != null) {
    //code
}

alert(null == undefined); //true
alert(null === undefined); //false
```
　　13、Boolean类型：true不一定等于1，false也不一定等于0。区分大小写。ECMAScript中所有值都与这两个Boolean值有等价的值。调用转型函数Boolean()可以将一个值转换其对应的Boolean值，返回结果取决于要转换的值的数据类型及其实际值。  

数据类型 | 转换为true的值 | 转换为false的值
---- | ----
Boolean | true | false
String | 任何非空字符串 | ""(空字符串)
Number | 任何非零数字值（包括无穷大） | 0和NaN
Object | 任何对象 | null
Undefined | n/a | undefined
 n/a或N/A，是not applicable的缩写，“不适用”。  
　　14、Number类型：整数和浮点数（双精度）。  
　　在进行算术计算时，八进制和十六进制值被转换为十进制值。  
　　浮点数的最高精度是17位小数，但计算精度远远不如整数，0.1+0.2≠0.3，因此不要测试特定的浮点数值。这是使用基于IEEE754数值的浮点计算的通病，并非只是ECMAScript。  
　　最小数值保存在Number.MIN_VALUE中，最大数值保存在Number.MIAX_VALUE，在大多数浏览器中分别为5e-324和1.7976931348623157e+308。超过值则输出为不能参与计算的(-)Infinity。使用isFinite()函数确定一个数值是否有穷。  
　　NaN叫非数值（Not a Number），是一个特殊的数值，表示本来要返回数值的操作数未返回数值而不抛出错误的情况。例如任何数值除以0本应抛出错误，但实际上返回NaN而不抛出错误，则不会影响其他代码执行。由于任何涉及NaN的操作都会返回NaN，则多步计算中间过程如果出现NaN则会导致问题。另外，NaN与包括其本身的任何值都不相等。使用isNaN()确定参数是否是或者能否转换为数值，是或能则返回false，该方法也可以用于对象。  
　　数值转换函数：Number()用于任何数据类型/parseInt()转换为整数/parseFloat()。  
```
alert(25); //输出十进制：25
alert(025); //前面加0，后面是八进制数字序列0-7，表示八进制，输出十进制值21
alert(029); //前面加0，后面有9，不属于八进制数字序列，前导0被忽略，表示十进制，输出十进制值29
alert(0x25); //前面加0x，后面是十六进制数字序列0-7和A-F，表示十六进制，输出十进制值37

var floatNum1 = 0.1; //浮点数必须包含小数点且气候必须至少有一位数字
var floatNum2 = 3.125e7; //31250000，科学计数法，e大小写都可
var floatNum3 = 3.125e-7; //0.0000003125

alert(0.1 + 0.2); //0.30000000000000004
alert(0.2 + 0.3); //0.5

alert(isFinite(Number.MAX_VALUE)); //ture
alert(isFinite(Number.MIN_VALUE)); //ture
alert(isFinite(Number.MAX_VALUE + Number.MAX_VALUE)); //false
alert(isFinite(Number.MAX_VALUE + Number.MIN_VALUE)); //ture

alert(Number.POSITIVE_INFINITY); //Infinity
alert(Number.NEGATIVE_INFINITY); //-Infinity

alert(NaN == NaN); //false
alert(isNaN(NaN)); //true，isNaN用于判断是不是NaN，当然就是它本身
alert(isNaN(10)); //false，是数值
alert(isNaN("10")); //false，能转换为10
alert(isNaN("a")); //true，不能转换数值
alert(isNaN(true)); //false，能转换为1
alert(isNaN(false)); //false，能转换为0

alert(Number(true)); //1
alert(Number(false)); //0
alert(Number(null)); //0
alert(Number(undefined)); //NaN
alert(Number("123")); //123
alert(Number("011")); //11，忽略前导0
alert(Number("1.1")); //1.1
alert(Number("0xf")); //15，转换为对应的十进制
alert(Number("")); //0
alert(Number("abc")); //NaN

console.log(parseInt(true)); //NaN，从第一个非空格字符开始，只要不是数字字符或负号就返回NaN
console.log(parseInt("")); //NaN
console.log(parseInt("011")); //11，忽略前导0
console.log(parseInt("1.1")); //1
console.log(parseInt("0xf")); //15，转换为对应的十进制
console.log(parseInt("070")); //70，ECMAScript3认为是56（八进制），ECMAScript5认为是70（十进制），已不再具有解析八进制的能力
console.log(parseInt("123abc")); //123，从遇到的第一个数字字符开始，直到遇到一个非数字字符
console.log(parseInt("123abc456")); //123
console.log(parseInt("0xAF")); //175，
console.log(parseInt("AF", 16)); //175，指定16为第二个参数，表示前面的数值为十六进制
console.log(parseInt("AF")); //NaN
console.log(parseInt("70", 8)); //56，指定8为第二个参数，表示前面的数值为八进制
console.log(parseInt("10", 2)); //2，指定2为第二个参数，表示前面的数值为二进制

console.log(parseFloat("1.2.3")); //1.2，只有第一个小数点有效
console.log(parseFloat("3.1e3")); //3100
console.log(parseFloat("12abc1")); //12，从第一个字符开始解析直到遇到一个无效的浮点数字字符，且没有小数点或小数点后为0会解析为整数
console.log(parseFloat("0xAF")); //0，只解析十进制，由于十六进制的第二个字符为x是无效浮点数字字符，因此十六进制的所有数据被解析为0
```
　　15、String类型：整数和浮点数（ 双精度）。  


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