# 第四章 变量、作用域和内存问题
　　1、Javascript变量松散类型的本质，决定了它只是在特定时间用于保存特定值的一个名字而已。由于不存在定义某个变量必须要保存何种数据类型值的规则，变量的值及其数据类型可以在脚本的生命周期内改变。  
　　2、ECMAScript比那辆可能包含两种不同数据类型的值：基本类型值和引用类型值。基本类型值：指简单的数据段；引用类型值：指可能由多个值构成的对象。  
　　3、在将一个值赋给变量时，解析器必须确定这个值是基本类型值还是引用类型值。  
　　4、5种基本数据类型：Undefined、Null、Boolean、Number、String。它们是按值访问的，因为可以操作保存在变量中的实际的值。  
　　5、引用类型：其值是保存在内存中的对象。Javascript不允许直接访问内存中的位置，也就是说不能直接操作对象的内存空间。在操作对象时，实际上是在操作对象的引用而不是实际的对象。  
　　6、ECMAScript中所有函数的参数都是按值传递的。可以把函数的参数想象乘局部变量。  

区别\变量类型 | 基本类型 | 引用类型
---- | ---- | ----
定义方式 | 创建变量并为该变量赋值 | 创建变量并为该变量赋值
访问方式  | 保存在变量中的实际的值 | 对象的引用
动态添加属性 | 否 | 是
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
　　当代码在一个环境中执行时，会创建变量对象的一个作用域链(scope chain)。作用域链保证对执行环境有权访问的所有变量和函数的有序访问。作用域链的前端，始终都是当前执行的代码所在环境的变量对象。如果这个环境是函数，则将其活动对象(activation object)作为变量对象。活动对象在最开始时只包含一个变量，即arguments对象(这个对象在全局环境中不存在)。作用域链中的下一个变量对象来自包含(外部)环境，而再下一个变量对象则来自下一个包含环境，一直延续到全局环境。全局执行环境的变量对象始终都是作用域链中的最后一个对象。  
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
　　9、没有块级作用域：。  