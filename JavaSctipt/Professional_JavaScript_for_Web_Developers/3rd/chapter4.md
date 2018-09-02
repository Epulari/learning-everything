# 第四章 变量、作用域和内存问题
　　1、Javascript变量松散类型的本质，决定了它只是在特定时间用于保存特定值的一个名字而已。由于不存在定义某个变量必须要保存何种数据类型值的规则，变量的值及其数据类型可以在脚本的生命周期内改变。  
　　2、ECMAScript比那辆可能包含两种不同数据类型的值：基本类型值和引用类型值。基本类型值：指简单的数据段；引用类型值：指可能由多个值构成的对象。  
　　3、在将一个值赋给变量时，解析器必须确定这个值是基本类型值还是引用类型值。  
　　4、5种基本数据类型：Undefined、Null、Boolean、Number、String。它们是按值访问的，因为可以操作保存在变量中的实际的值。  
　　5、引用类型：其值是保存在内存中的对象。Javascript不允许直接访问内存中的位置，也就是说不能直接操作对象的内存空间。在操作对象时，实际上是在操作对象的引用而不是实际的对象。  
　　6、ECMAScript中所有函数的参数都是按值传递的。可以把函数的参数想象乘局部变量。  

特点 | 基本类型 | 引用类型
---- | ---- | ----
定义方式 | 创建变量并为该变量赋值 | 创建变量并为该变量赋值
占用空间 | 固定大小 | 不固定
保存位置 | 栈内存中 | 堆内存中
访问方式  | 保存在变量中的实际的值 | 对象的指针
能够动态添加属性 | 否 | 是
复制变量值 | 复制到新值中的副本为真实的值 | 复制到新值中的副本是指向对象的指针
修改复制后的变量 | 原值不变 | 原值改变
传递参数 | 按值传递 | 按值传递
传递参数 | 将值复制给局部变量 | 将值在内存中的地址复制给局部变量
修改函数内参数的值 | 原值不变 | 原值不变
修改函数内参数的属性的值 | 原值不变 | 原值改变

```
//复制变量
//复制对象并修改复制后的属性值
var obj1 = {name: 'Ep'};
console.log(obj1.name); //Ep 原属性值
var obj2 = obj1;
obj2.name = "Epu";
console.log(obj1.name); //Epu 修改复制后的值原值也改变了


//传递参数
//将对象作为函数参数并在函数内修改参数的属性值
function modifyObj(obj) {
    obj.name = "Epu"; //修改了该地址中的对象的属性的值
    return obj; //返回的是对象obj的地址
}
var obj1 = {name: 'Ep'};
var obj2 = modifyObj(obj1); //传递了obj1的地址
console.log(obj1.name); //Epu 函数内修改了obj1指向的对象的属性的值
console.log(obj2.name); //Epu obj2指向的是obj1指向的对象

//将对象作为函数参数并在函数内修改该对象
function modifyObj(obj) {
    obj.name = "Epu";
    console.log(obj.name); //Epu 修改该地址中的对象的属性的值
    obj = new Object(); //重新实例化obj，则obj指向了一个新的对象的地址
    obj.name = "Ep"; //设置新的对象的属性值 语句1
    console.log(obj.name); //Ep 输出新的对象的属性值 如果不要语句1，则该处输出undefined
    return obj; //返回新的对象的地址，如果不返回，则新的对象为局部对象，在函数执行完毕后立即被销毁
}
var obj1 = {name: 'Ep'};
var obj2 = modifyObj(obj1); //传递了obj1的地址
console.log(obj1.name); //Epu 函数内修改了obj1指向的对象的属性的值
console.log(obj2.name); //Ep obj2指向的是新的对象，则输出新的对象的属性值，如果不要语句1，则该处输出undefined
```
　　7、检测类型：typeof操作符用于确定一个变量是字符串、数值、布尔值还是undefined的最佳工具，而对于对象会null会都返回"object"。instanceof操作符用于判断变量具体是类型类型的对象。注意看下面对null的判断，都是false。  
```
//typeof
console.log(typeof 1); //number
console.log(typeof "a"); //string
console.log(typeof true); //boolean
console.log(typeof undefined); //undefined

console.log(typeof function(){}); //function

console.log(typeof null); //object
console.log(typeof {name: 'Ep'}); //object

//instanceof
console.log({} instanceof Object); //true {}是Object类型吗
console.log({} instanceof Array); //false {}是Array类型吗
console.log({} instanceof RegExp); //false {}是RegExp类型吗

console.log([] instanceof Object); //true []是Object类型吗
console.log([] instanceof Array); //true []是Array类型吗
console.log([] instanceof RegExp); //false []是RegExp类型吗

console.log(function(){} instanceof Object); //true function是Object类型吗
console.log(function(){} instanceof Array); //false function是Array类型吗
console.log(function(){} instanceof RegExp); //false function是RegExp类型吗

console.log(null instanceof Object); //false null是Object类型吗
console.log(null instanceof Array); //false null是Array类型吗
console.log(null instanceof RegExp); //false null是RegExp类型吗
```
　　8、执行环境：定义了变量或函数有权访问的其它数据，决定了它们各自的行为。其类型共两种：全局和局部(函数)。每个执行环境都有一个与之关联的变量对象(variable object)，环境中定义的所有变量和函数都保存在这个对象中。代码无法访问这个对象，解析器在处理数据时会在后台使用它。某个执行环境中的所有代码执行完毕后，该环境及其变量和函数定义全都被销毁。  
　　全局执行环境：最外围的执行环境。根据ECMAScript实现所在的宿主环境不同，表示执行环境的对象也不一样。在Web浏览器中，全局执行环境被认为是window对象，所有全局变量和函数都是作为window对象的属性和方法创建的。全局执行环境直到应用程序退出时被销毁，如关闭网页或者浏览器。  
　　每个函数都有自己的执行环境。当执行流进入一个函数时，函数的环境会被推入一个环境栈中，函数执行之后，栈将其环境弹出，把控制权返回给之前的执行环境。  
　　执行环境决定了变量的声明周期，以及哪一部分代码可以访问其中的变量。当代码在一个环境中执行时，会创建变量对象的一个作用域链(scope chain)。作用域链保证对执行环境有权访问的所有变量和函数的有序访问。作用域链的前端，始终都是当前执行的代码所在环境的变量对象。如果这个环境是函数，则将其活动对象(activation object)作为变量对象。活动对象在最开始时只包含一个变量，即arguments对象(这个对象在全局环境中不存在)。作用域链中的下一个变量对象来自包含(外部)环境，而再下一个变量对象则来自下一个包含环境，一直延续到全局环境。全局执行环境的变量对象始终都是作用域链中的最后一个对象。  
　　标识符解析时沿着作用域链一级一级地搜索标识符的过程。搜索过程始终从作用域链的前端开始，逐级向后回溯，直到找到标识符为止(如果找不到标识符，通常会导致错误发生)。  
　　8、延长作用域链：有些语句可以在作用域链的前端临时增加一个变量对象，该变量对象会在代码执行后被移除。try-catch语句的catch块；with语句。对catch语句来说会创建一个新的变量对象，其中包含的时被抛出的错误对象的声明。对witch语句来说，会将指定的对象添加到作用域链中。  
```
//with
function withF1() {
    var a = "u";
    var b = {name: 'Ep'};
    with(b) {
        var c = name + a;
    }
    console.log(c); //with语句内部定义了c，在with语句的执行环境内可以检测到
}
withF1();
console.log(c); //报错 with语句内部定义了c，在with语句的执行环境外不能检测到

function withF2() {
    var a = "u";
    var b = {name: 'Ep'};
    function withF3() {
        var c = b.name + a;
    }
    withF3();
    console.log(c); //报错 普通作用域链，外部检测不到内部的变量
}
withF2();
```
　　9、没有块级作用域：if语句、for语句等没有单独的执行环境，它们和上下文是相同的执行环境。使用var声明的变量会自动被添加到最接近的环境中。如果初始化变量时没有使用var声明，该变量会自动被添加到全局环境。在某个环境中为了读取或写入某个变量时，从作用域链的前端（当前环境）逐级向上查询匹配，直到全局环境的变量对象，在这个搜索过程中如果存在一个局部的变量的定义则自动停止搜索，因此如果局部环境和父环境存在同名标识符，则识别的是局部环境内的标识符；如果全局环境中也没有找到该标识符，则代表变量未声明。  
```
//没有块级作用域的具体体现：for语句没有单独的执行环境
for(var i = 0; i < 10; i++) {
    //coding
}
console.log(i); //10
```
　　10、垃圾收集：JavaScript具有自动垃圾收集机制，即执行环境会负责管理代码执行过程中使用的内存。原理：垃圾收集器会按照固定的时间间隔（或代码执行中预定的收集时间），周期性地找出不再继续使用的变量，然后释放其占用的内存。  
　　标记清除（mark-and-sweep）：JavaScript中最常用的垃圾收集方式。垃圾收集器在运行的时候回给存储在内存中的所有变量都加上标记（例如标记为“进入环境”），然后，去掉环境中的变量以及被环境中的变量引用的变量的标记；在此之后再被加上标记的变量将被视为准备删除的变量（例如标记为“离开环境”），因为环境中的变量已经无法访问到这些变量了；最后，垃圾收集器完成内存清除工作，销毁那就写带标记的值并回收它们所占用的内存空间。  
　　引用计数（reference counting）：不太常见的垃圾收集策略。其含义是跟踪记录每个值被引用的次数。  
　　IE浏览器的JavaScript引擎使用标记清除策略实现，但JavaScript访问的COM对象时基于引用计数策略的。因此，只要在IE中设计COM对象，就会存在循环引用的问题。IE9把BOM和DOM对象都转换成了真正的JavaScript对象。  
　　垃圾收集器是周期性运行的，如果变量分配的内存数量很可观，那么回收工作量是相当大的，因此确定垃圾收集的时间间隔是非常重要的。如IE7及以后版本：设置触发垃圾收集的变量分配、字面量和（或）数组元素的临界值被调整为动态修正。首先设置默认值，如果垃圾收集例程回收的内存分配量低于15%，则临界值加倍；如果例程回收了85%的内存分配量，则将各种临界值重置回默认值。  
```
//引用计数的循环引用
//标记清除：函数执行后，这两个对象都离开了作用域，回收两个对象
//引用计数：声明变量并将引用类型值(objA)赋给该变量，这个值(objA)引用次数从0变为1; 这个值又被赋给B的属性，引用次数变为2，因此永远不会为0，不会被清除，这个函数被调用次数越多，占用内存越大
function problem() {
    var objA = new Object();
    var objA = new Object();
    
    objA.someotheobject = objB;
    objB.anotherobject = objA;
}


//IE中使用COM对象导致的循环引用问题
//DOM元素(element)與原生JavaScript对象(myObject)之间创建了循环引用
//变量myObject有一个名为element的属性执行element对象
//变量element有一个属性名叫someObject回指myObject
//因此即使该DOM从页面中移除，它也永远不会被回收
var element = document.getElementById("ele");
var myObject = new Object();
myObject.element = element;
element.someObject = myObject;

//使用下面的代码消除前面例子中创建的循环引用
//将变量设置为null意味着切断变量与它以前引用的值直接的连接，当垃圾收集器下次运行时，就会删除这些值并回收它们占用的内存
myObject.element = null;
element.someObject = null;
```
　　11、管理内存：出于安全方面的考虑——防止运行JavaScript的网页耗尽全部系统内存而导致系统崩溃，JavaScript分配给Web浏览器的可用内存数量通常比分配给桌面应用程序的少。内存限制问题不仅会影响给变量分配内存，同时还会影响调用栈以及在一个线程中能够同时执行的语句数量。  
　　优化内存占用的最佳方式：为执行中的代码只保存必要的数据。一旦数据不再有用，将其设置为null来解除引用（dereferencing）以让值脱离执行环境，以便垃圾收集器下次运行时将其回收。这一做法适用于大多数全局变量和全局对象的属性，而拒不变量会在它们离开执行环境时自动被解除引用。  
