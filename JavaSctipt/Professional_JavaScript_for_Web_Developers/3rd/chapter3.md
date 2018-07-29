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
console.log(c); //错误，局部变量在函数退出后被销毁
console.log(d); //"d" ，省略var创建全局变量，但不推荐，严格模式下抛出ReferenceError错误

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
console.log(typeof message); //"string"
console.log(typeof(message)); //"string"
console.log(typeof 95); //"number"
console.log(typeof null); //特殊值null被认为是一个空的引用对象
```
　　typeof是操作符，因此上面例子中的圆括号可以使用，但不是必需。  
　　注意：Safari5及之前的版本、Chrome7及之前的版本在对正则表达式调用typeof操作符时会返回"function"，而其他浏览器在这种情况下会返回"object"。  
　　12、Undefined和Null类型：这两个数据类型各自都只有一个值，前者是undefined，后者是null。  
　　在定义变量但还未真正赋值时，最好明确地让变量保存null值，这样不仅可以体现null 作为空对象指针的惯例，而且也有助于进一步区分null和undefined。  
```
var a; //声明变量a但未定义，默认赋值为undefined
// var b; //未声明变量b
console.log(a); //"undefined"
console.log(b); //报错
console.log(typeof a); //"undefined"
console.log(typeof b); //"undefined"

var c = null;
console.log(typeof c); //"object"
if(c != null) {
    //code
}

console.log(null == undefined); //true
console.log(null === undefined); //false
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
console.log(25); //输出十进制：25
console.log(025); //前面加0，后面是八进制数字序列0-7，表示八进制，输出十进制值21
console.log(029); //前面加0，后面有9，不属于八进制数字序列，前导0被忽略，表示十进制，输出十进制值29
console.log(0x25); //前面加0x，后面是十六进制数字序列0-7和A-F，表示十六进制，输出十进制值37

var floatNum1 = 0.1; //浮点数必须包含小数点且气候必须至少有一位数字
var floatNum2 = 3.125e7; //31250000，科学计数法，e大小写都可
var floatNum3 = 3.125e-7; //0.0000003125

console.log(0.1 + 0.2); //0.30000000000000004
console.log(0.2 + 0.3); //0.5

console.log(isFinite(Number.MAX_VALUE)); //ture
console.log(isFinite(Number.MIN_VALUE)); //ture
console.log(isFinite(Number.MAX_VALUE + Number.MAX_VALUE)); //false
console.log(isFinite(Number.MAX_VALUE + Number.MIN_VALUE)); //ture

console.log(Number.POSITIVE_INFINITY); //Infinity
console.log(Number.NEGATIVE_INFINITY); //-Infinity

console.log(NaN == NaN); //false
console.log(isNaN(NaN)); //true，isNaN用于判断是不是NaN，当然就是它本身
console.log(isNaN(10)); //false，是数值
console.log(isNaN("10")); //false，能转换为10
console.log(isNaN("a")); //true，不能转换数值
console.log(isNaN(true)); //false，能转换为1
console.log(isNaN(false)); //false，能转换为0

console.log(Number(true)); //1
console.log(Number(false)); //0
console.log(Number(null)); //0
console.log(Number(undefined)); //NaN
console.log(Number("123")); //123
console.log(Number("011")); //11，忽略前导0
console.log(Number("1.1")); //1.1
console.log(Number("0xf")); //15，转换为对应的十进制
console.log(Number("")); //0
console.log(Number("abc")); //NaN

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
　　15、String类型：零或多个16位Unicode字符组成的字符序列，即字符串。单引号与双引号表示完全相同。  
　　特殊字符字面量，也叫转义序列，用于表示非打印字符，或具有其他用途的字符：
```
\n  //换行
\t  //制表
\b  //空格
\r  //回车
\f  //换页
\\  //斜杠
\'  //单引号（'），在用单引号表示的字符串中使用，如'He said, \'hey.\''
\"  //双引号（"），在用双引号表示的字符串中使用，如"He said, \"hey.\""
\xnn  //以十六进制代码nn表示的一个字符（其中n为0-F），如\41表示“A”
\unnnn  //以十六进制代码nnnn表示的一个Unicode字符（其中n为0-F），如\u03a3表示希腊字符Σ
```
　　字符串是不可变的，对一个字符串a的内容修改的原理是：创建新字符串b，将修改后的内容赋给b，销毁a，将b设为a。  
　　把值转换为字符串的方位有.toString()方法和String()函数。  
```
var a = 11;
console.log(a.toString()); //"11"，默认十进制
console.log(a.toString(2)); //"1011"，二进制，toString()可以传递一个参数：输出数值的基数
console.log(a.toString(8)); //"13"，八进制
console.log(a.toString(10)); //"11"，十进制
console.log(a.toString(16)); //"b"，1十六进制

var b = true;
console.log(a.toString()); //"true"
console.log(String(b)); //"true"

var c = null;
console.log(c.toString()); //error
console.log(String(c)); //"null"

var d = undefined;
console.log(d.toString()); //error
console.log(String(d)); //"undefined"
```
　　16、Object类型：ECMAScript中的对象其实是一组数据和功能的集合。在ESMAScript中，Object类型是所有它的实例的基础，也即是Object类型所具有的任何属性和方法也同样存在于更具体的对象中。  
　　Object的每个实例具有下列属性和方法：  
　　(1) constructor: 保存着用于创建当前对象的函数。  
　　(2) hasOwnProperty(propertyName): 用于检查给定的属性在当前对象实例中（而不是在实例的原型中）是否存在。其中，作为参数的属性名（propertyName）必须以字符串形式指定（例如：o.hasOwnProperty("name")）。  
　　(3) isPrototypeOf(object): 用于检查传入的对象是否是传入对象的原型。  
　　(4) propertyIsEnumerable(propertyName): 用于检查给定的属性是否能够使用for-in语句来枚举，与hasOwnProperty()方法一样，作为参数的属性名必须以字符串形式指定。  
　　(5) toLocalString(): 返回对象的字符串表示，该字符串与执行环境的地区对应。  
　　(6) toString(): 返回对象的字符串表示，该字符串与执行环境的地区对应。  
　　(7) valueOf(): 返回对象的字符串、数值或布尔值表示。通常与toString()方法的返回值相同。  
　　在ECMAScript中Object是所有对象的基础，因此所有对象都具有这些基本的属性和方法。  
```
var a = new Object(); //创建自定义对象，如果不传参可以省略括号，但不推荐；对于该例子而言，构造函数就是Object()
```
　　17、操作符：算术操作符（如加号或减号）、位操作符、关系操作符和相等操作符。它们能够适用于字符串、数字值、布尔值、对象（相应操作符通常会调用对象的valueOf()和（或）toString()方法，以便取得可以操作的值）。  
　　18、一元操作符：只能操作一个值的操作符。最简单的操作符。主要用于基本的算术运算，也可以像下面例子中一样用于转换数据类型。  
```
//递增和递减操作符
var k = 10;
//以下计算都相互独立
++k; //前置递增操作符 k=11
--k; //前置递减操作符 k=9
k++; //后置递增操作符 k=10
k--; //后置递增操作符 k=10

var p = 10;
var q = 20;
//以下两个计算相互独立
//计算一：前置递增和递减操作与执行语句的优先级相等，语句从左至右被求值
var m1 = --p + q; //29
var m2 = p + q; //29 经过上面的运算后，b少1
//计算二：后置递增和递减操作是在包含它们的语句被求值之后执行的
var n1 = p-- + q; //30
var n2 = p + q; //29 经过上面的运算后，b少1

var a = "2";
var b = "z";
var c = false;
var d = 1.1;
var e = {
    valueOf: function() {
        return -1;
    }
};
a++; //3 包含有效数字字符的字符串，字符串变量变成数值变量，再执行加减1操作
b++; //NaN 不包含有效数字字符的字符串，字符串变量变成数值变量，将变量的值设置为NaN
c++; //1 布尔值转换为数值变量0或1再进行加减1操作
d++; //1.1
e++; //-1 对象变量变成数值变量，先调用对象的valueOf()方法以取得可供操作的值，然后执行操作；如果结果是NaN，则调用toString()方法再执行操作


//一元加和减操作符: 对数值不产生影响，非数值会进行转换
var f = 1;
var g = "01";
var h = "1.1";

a = +a; //2
b = +b; //NaN
c = +c; //0
d = +d; //1.1
e = +e; //-1
f = +f; //1
g = +g; //1
h = +h; //1.1
//一元操作符的主要作用：表示负数；非数值转换后再变为负数
a = -a; //-2
b = -b; //NaN
c = -c; //0
d = -d; //-1.1
e = -e; //1
f = -f; //-1
g = -g; //-1
h = -h; //-1.1
```
　　19、位操作符：ECMAScript中的所有数值都以IEEE-754 64位格式存储，但位操作符先将64位值转换为32位整数，然后执行操作，再将结果转换为64位，因此对开发人员来说，整个过程就像是只存在32位的整数一样。  
　　对于有符号的整数，32位中的前31位（从右往左）用于表示整数的值，第32位表示数值的符号：0表示整数，1表示负数，这个位叫符号位，它决定了其他位数值的格式。  
　　正数以纯二进制格式存储，31位中的每一位都表示2的幂。第一位（叫做位0）表示2<sup>0</sup>，第二位表示2<sup>1</sup>，以此类推，没有用到的位以0填充，即忽略不计。18的二进制表示为10010（前面有忽略的27个0）。  
　　负数以二进制补码格式存储。求-18的二进制码：  
(1) 求这个数值绝对值（18）的二进制码:  
0000 0000 0000 0000 0000 0000 0001 0010  
(2) 求二进制反码，即以0代替1，以1代替0：  
1111 1111 1111 1111 1111 1111 1110 1101  
(3) 得到的二进制加1即为结果：  
1111 1111 1111 1111 1111 1111 1110 1110  
　　在ECMAScript中以二进制字符串形式输出一个负数时，看到的结果其实是负数绝对值的二进制码前面加上一个负号。  
```
var num = -18;
console.log(num.toString(2)); //-10010
```
　　注意：在处理有符号整数时，不能访问位31，即符号位。默认情况下，ECMAScript中的所有整数都是符号整数。但依旧存在无符号整数，无符号整数只能是整数，它的第32位不再表示符号，因此其值可以更大。  


  
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