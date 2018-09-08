# 第五章 引用类型
　　1、引用类型：引用类型的值（对象）时引用类型的一个实例。在ECMAScript中，引用类型是一种数据结构，用于将数据和功能组织在一起。引用类型有时候也被称为对象定义，因为它们描述的是一类对象所具有的属性和方法。虽然ECMAScript从技术上讲是一门面向对象的语言，但它不具备传统的面向对象语言所支持的类和接口等基本结构。因此虽然它也常被称为类，但不妥当，它们并不是相同的概念。  
```
//没有块级作用域的具体体现：for语句没有单独的执行环境
for(var i = 0; i < 10; i++) {
    //coding
}
console.log(i); //10


//创建Object引用类型的一个新实例，然后把该实例保存在变量obj中
//使用的构造函数是Object，它只为新对象定义了默认的属性和方法
var obj = new Object();
```
　　2、Object类型：ECMAScript中使用最多的一个类型。对于在应用程序中存储和传输数据而言，是非常理想的选择。创建Object实例的方法：使用new操作符后跟Object构造函数、使用对象字面量语法（这种方法实际上不会调用Object构造函数）。后者也是向函数传递大量可选参数的首选方式。访问对象属性的方法：点表示法、方括号表示法。通常使用点表示法，但属性名使用关键字或保留字、有空格的字符、导致语法错误的字符等时使用方括号表示法。  
　　Object是一个基础类型，所有其他类型都从Object继承了基本行为。  
```
//创建Object实例方法1：使用new操作符后跟Object构造函数
var obj1 = new Object();
//访问对象属性的方法：点表示法、方括号表示法
//有该属性名时改变属性值，没有改属性名时添加属性
obj1.a = "aa";
obj1["b"] = "bb";

//创建Object实例方法2：使用对象字面量语法
var obj2 = {
    name: "name", //一般定义属性名时是否加引号无所谓
    "this": "t", //使用关键字或者保留字作为属性名需要用引号
    "first name": "name"  //使用有空格的字符作为属性名需要用引号
};

//访问对象属性的方法：点表示法、方括号表示法
console.log(obj1["a"]); //aa
console.log(obj1.b); //bb
//属性名使用关键字或保留字、有空格的字符、导致语法错误的字符等时使用方括号表示法
console.log(obj2.this); //t this是关键字，最好使用方括号表示法
console.log(obj2["first name"]); //name
//console.log(obj2.first name); //报错
```
　　3、所有对象都具有toLocaleString()、toString()、valueOf()方法。  
　　4、Array类型：创建数组的方法：使用Array构造函数（可以省略new操作符）、使用数组字面量表示法。  

性质 | ECMAScript | C/C++/JAVA/C#
---- | ---- | ----
存储方式 | 有序列表 | 有序列表
一个数组中每项数据的类型 | 可以不同 | 一定相同
大小 | 动态调整 | 定义时就需要固定
```
//使用Array构造函数创建数组
var a = new Array();
//常见长度为10的数组
var b = new Array(10);
//创建包含2个字符串的数组
var c = new Array("he", "she");
//可以省略new操作符
var d = Array();

//使用数组字面量表示法
var f = ["a", "b"];

//方括号表示法
console.log(f[0]); //获取数组f的第一个元素，其索引值为0
f[1] = "c"; //修改数组f的第二个元素值，其索引值为1
f[2] = "d"; //为数组f添加第三个值，其索引值为2
console.log(f); //[ 'a', 'c', 'd' ]
```
　　5、检测数组：instanceof操作符。该操作符假定只有一个全局执行环境。如果网页中包含多个框架，则实际上存在两个以上不同的全局执行环境，从而存在两个以上不同版本的Array构造函数。如果从一个框架向另一个框架传入一个数组，那么传入的数组与在第二个框架中原生创建的数组分别具有各自不同的构造函数。ECMAScript5中新增Array.isArray()方法用于最终确定某个值到底是不是数组，而不管它在哪个全局执行环境中创建。支持该方法的浏览器：IE9+、Firefox4+、Safari5+、Opera10.5+、Chrome。  
```
//数组f
console.log(f instanceof Array); //true
console.log(Array.isArray(f)); //true
//字符串f
console.log("f" instanceof Array); //false
console.log(Array.isArray("f")); //false
```
　　6、数组转换方法：toString()、valueOf()、toLocaleString()方法。如果数组中的某一项值为null或undefined，则该值在这四种方法返回的结果中以空字符串表示。  
```
console.log(f.toString()); //a,b 返回由数组中每个值的字符串形式拼接而成的一个以逗号分隔的字符串
console.log(f.valueOf()); //[ 'a', 'b' ] 返回的还是数组
console.log(f.toLocaleString()); //a,b 返回由数组中每个值的字符串形式拼接而成的一个以逗号分隔的字符串

console.log(f.join("||")); //a||b 返回的字符串是以其他分隔符来分隔每个字符，参数为作为分隔符的字符串
```
　　7、数组栈方法：使用push()和pop()方法实现类栈行为。前者可以接收任意数量的参数，把它们逐个加到数组末尾，返回修改后的数组长度；后者不能接收参数，移除数组末尾一项并返回该项。它们都改变数组长度。  
　　8、数组队列方法：使用push()和shift()方法实现类队列方法。后者不接收参数，移除数组中的第一个项并返回该项，改变数组长度。  
```
console.log(f.push("c")); //3
console.log(f.pop("c")); //c
console.log(f.shift("c")); //a
```
　　9、数组重排序方法：反转数组项的顺序：reverse()。按字符串升序排列数组项（数字也会被转换为字符串）：sort()方法。它们的返回值都是排序后的数组。  
```
var a = [1, 5, 10, 15];
console.log(a.sort()); //[ 1, 10, 15, 5 ] 按字符串升序排列数组项
console.log(a.sort(compare1)); //[ 1, 5, 10, 15 ]
//这个比较函数可以适用于大多数数据类型，只要将其作为参数传给sort()方法即可
function compare1(val1, val2) {
    if (val1 < val2) {
        return -1; //不应该交换两个数，返回负数
    } else if (val1 > val2) {
        return 1; //应该交换两个数，返回正数
    } else {
        return 0; //相等则返回0
    }
}
console.log(a.sort(compare2)); //[ 1, 5, 10, 15 ]
//对于数值类型或其valueOf()方法会返回数值类型的对象类型，使用这个函数更简单
function compare2(val1, val2) {
    return val1 - val2;
}
```
　　10、数组操作方法：复制数组或创建新数组：concat()、基于数组部分项创建新数组slice()、删除或插入项splice()。  
```
//concat(): 返回复制的数组或构建的新数组
console.log(a.concat()); //[ 1, 5, 10, 15 ]
console.log(a.concat([2, 3])); //[ 1, 5, 10, 15, 2, 3 ]
console.log(a.concat("ww", "mm")); //[ 1, 5, 10, 15, 'ww', 'mm' ]

//slice(): 基于当前数组中的一个或多个项创建一个新数组
console.log(a.slice(2)); //[ 10, 15 ] 返回该位置到末尾所有项
console.log(a.slice(2, 3)); //[ 10 ] 返回起始位置和结束位置中间项，包括起始，不包括结束，不影响原数组

//splice(): 删除数组项或插入项，改变原数组，返回删除的项，当只插入不删除时则返回空数组
var a = [1, 5, 10, 15];
console.log(a.splice(1, 2)); //[ 5, 10 ] 参数：起始位置(要删除的第一项的位置)、要删除的项数
console.log(a); //[ 1, 15 ] 改变原数组
var a = [1, 5, 10, 15];
console.log(a.splice(2, 0, "ww", "mm")); //[] 参数：起始位置、0(要删除的项数)、要插入的项(从第三个参数开始，后面所有的参数都是要插入的项)
console.log(a); //[ 1, 5, 'ww', 'mm', 10, 15 ] 改变原数组
var a = [1, 5, 10, 15];
console.log(a.splice(2, 2, "ww", "mm", "kk")); //[ 10, 15 ] 参数：起始位置、要删除的项数、要插入的项(从第三个参数开始，后面所有的参数都是要插入的项)
console.log(a); //[ 1, 5, 'ww', 'mm', 'kk' ] 改变原数组
```
　　11、数组位置方法：indexOf()和lastIndexOf()。都接收两个参数：要查找的项和（可选的）表示查找起点位置的索引。前者从数组起始3向后查找，后者从数组末尾向前查找。在进行比较时，使用的是全等操作符。  
```
var a = [1, 5, 10, 15];
console.log(a.indexOf("1")); //-1 参数：要查找的项
console.log(a.indexOf(10)); //2 参数：要查找的项
console.log(a.indexOf(10, 1)); //2  参数：要查找的项、查找起点位置的索引
console.log(a.indexOf(10, 3)); //-1  参数：要查找的项、查找起点位置的索引
console.log(a.lastIndexOf("1")); //-1  参数：要查找的项
console.log(a.lastIndexOf(10)); //2  参数：要查找的项
console.log(a.lastIndexOf(10, 2)); //2  参数：要查找的项、查找起点位置的索引
console.log(a.lastIndexOf(10, 1)); //-1  参数：要查找的项、查找起点位置的索引
```
　　12、数组迭代方法：every()、some()、filter()、map()、forEach()。  
```
//方法的参数：每一项上运行的函数、（可选）运行该函数的作用域对象——影响this的值
//函数的参数：数组项的值、该项在数组中的位置、数组对象本身

//every(): 对数组中的每一项运行给定函数，如果每项都返回true，则返回true
//用于查询数组中的项是否满足某个条件
var _every = a.every(function(item, index, a) {
    return (item > 8);
});
console.log(_every); //false

//some(): 对数组中的每一项运行给定函数，只要有一项返回true，则返回true
//用于查询数组中的项是否满足某个条件
var _some = a.some(function(item, index, a) {
    return (item > 8);
});
console.log(_some); //true

//filter(): 对数组中的每一项运行给定函数，返回该函数会返回true的项生成的数组
//利用指定的函数确定是否在返回的数组中包含某一项
var _filter = a.filter(function(item, index, a) {
    return (item > 8);
});
console.log(_filter); //[ 10, 15 ]

//map(): 对数组中的每一项运行给定函数，返回每次函数调用的结果组成的数组
//用于对数组某一项进行相同操作，适合创建包含的项与另一个数组一一对应的数组
var _map = a.map(function(item, index, a) {
    return (item > 8);
});
console.log(_map); //[ false, false, true, true ]

//forEach(): 对数组中的每一项运行给定函数，没有返回值
//本质上与for循环迭代数组一样
var _forEach = a.forEach(function(item, index, a) {
    //coding
});
```
　　13、数组归并方法：reduce()和reduceRight()。迭代数组的所有项，然后构建一个最终返回的值。前者从数组第一项开始逐个遍历到最后，后者从数组末尾开始向前遍历到第一项。  
```
//方法的参数：一个在每一项上调用的函数、（可选）作为归并基础的初始值
//函数的参数：前一个值、当前值、项的索引、数组对象，这个函数返回的任何值都会作为第一个参数自动传给下一项
var a = [1, 5, 10, 15];
//第一次执行：prev: 1, cur: 5 从第二个元素开始
var _reduce = a.reduce(function(prev, cur, index, array) {
    return prev + cur;
})
console.log(_reduce); //31
//第一次执行：prev: 15, cur: 10 从倒数第二个元素开始
var _reduceR = a.reduceRight(function(prev, cur, index, array) {
    return prev + cur;
})
console.log(_reduceR); //31
```
　　14、Date类型：在早期Java中的java.util.Date类基础上构建的。使用UTC(Coordinated Universal Time，国际协调时间)1970年1月1日午夜（零时）开始经过的毫秒数来保存日期，因而其保存的日期能够精确到1970年1月1日之前或之后的285616年。  
　　调用Date构造函数而不传参，新创建的对象自动获得当前日期的时间。  
　　15、根据特定的日期和时间创建日期对象，必须传入表示该日期的毫秒数（即从UTC时间1970年1月1日午夜起至该日期止经过的毫秒数）。Date.parse()和Date.UTC()方法能够简化这一计算过程。前者接收一个表示日期的字符串参数并返回相应日期的毫秒数或NaN，参数格式不定，通常因地区而异。在Date构造函数中传递表示日期的字符串，后台也会调用该方法。后者的参数是年份、以0开始的月份、天数、以0开始的小时数、分钟、秒及毫秒数，前两个参数必需，省略天数则假设为1，省略其他参数则假设为0。  
```
//parse()方法
//本地时间是指：参数的时间本地时间，而输出的是零时区的对应时间
new Date(Date.parse("2018/9/5")); //2018-09-04T16:00:00.000Z 参数：yy/mm/dd 本地时区 输出本地时间需要加8小时的毫秒数28800000
new Date(Date.parse("2018/9/5") + 28800000); //2018-09-05T00:00:00.000Z
new Date(Date.parse("9/5/2018")); //2018-09-04T16:00:00.000Z 参数：mm/dd/yy 本地时区 输出本地时间需要加8小时的毫秒数28800000
new Date(Date.parse("September 5, 2018")); //2018-09-04T16:00:00.000Z 本地时区 参数：月(英文,可以用缩写) 日,年
new Date(Date.parse("Wednesday September 5 2018 8:20:00 GMT")); //2018-09-05T08:20:00.000Z GMT时区 参数：星期(可选) 月 日 年 时:分:秒 时区(可选)
new Date(Date.parse("Wednesday September 5 2018 8:20:00 UTC")); //2018-09-05T08:20:00.000Z UTC时间 参数：星期(可选) 月 日 年 时:分:秒 时区(可选)
new Date(Date.parse("Wednesday September 5 2018 8:20:00")); //2018-09-05T08:20:00.000Z GMT时区 参数：星期(可选) 月 日 年 时:分:秒 时区(可选)
new Date(Date.parse("2018-09-05T08:20:00")); //2018-09-05T00:20:00.000Z 本地时区 参数：yy-mm-ddThh:ss:min
//不要parse()方法而直接将parse的参数写在Date构造函数中，后台会调用parse()方法，输出结果相同

//UTC()方法
//不要UTC()方法而直接将UTC的参数写在Date构造函数中，后台会调用UTC()方法，但输出时间从GMT时区变为了本地时区
new Date(Date.UTC(2018, 8, 5, 8, 20)); //2018-09-05T08:20:00.000Z GMT时区 参数：年 以0开始的月份 天数 以0开始的小时数 分钟 秒 毫秒(前两者必须，其他可选)
new Date(2018, 8, 5, 08, 20) //2018-09-05T00:20:00.000Z 本地时区
```
　　16、Date.now()方法：返回调用这个方法时的日期和时间的毫秒数。在函数开始和结尾时分别调用这个方法可以计算函数运行的时间。在构造函数的new操作符前添加+操作符也可以达到同样的目的。  
```
console.log(Date.now());
console.log(+new Date());
```
　　17、继承的方法：toString()方法返回带有时区信息的日期和时间，其中时间一般以军用时间（小时范围为0-23）表示。toLocaleString()方法按照与浏览器设置的时区相适应的格式返回日期和格式，具体格式因浏览器而异。这两者的差别仅在调试代码时比较有用，而在显示日期和时间时没有什么价值。valueOf()返回日期的毫秒表示，可以用来比较日期值（先到来的日期的毫秒数小于后到来的日期的毫秒数）。  
```
console.log(new Date(Date.parse("2018/9/5"))); //2018-09-04T16:00:00.000Z
console.log(new Date(Date.parse("2018/9/5")).toString()); //Wed Sep 05 2018 00:00:00 GMT+0800 (中国标准时间)
console.log(new Date(Date.parse("2018/9/5")).toLocaleString()); //2018-9-5 00:00:00
console.log(new Date(Date.parse("2018/9/5")).valueOf()); //1536076800000

console.log(new Date(Date.UTC(2018, 8, 5, 8, 20))); //2018-09-05T08:20:00.000Z GMT时区
console.log(new Date(Date.UTC(2018, 8, 5, 8, 20)).toString()); //Wed Sep 05 2018 16:20:00 GMT+0800 (中国标准时间)
console.log(new Date(Date.UTC(2018, 8, 5, 8, 20)).toLocaleString()); //2018-9-5 16:20:00
console.log(new Date(Date.UTC(2018, 8, 5, 8, 20)).valueOf()); //1536135600000
```
　　18、日期格式化方法：toDateString(): 星期 月 日 年。toTimeString(): 时:分:秒 时区。toLocaleDateString(): 年-月-日。toLocaleTimeString(): 时:分:秒。toUTCString(): 星期, 日 月 年 时:分:秒 时区，还有等价的toGMTString()方法，但不推荐使用。这些字符串格式方法的输出也会因浏览器而异，因此没有哪种方法能够用来在用户界面显示一致的日期信息。  
```
console.log(new Date(Date.parse("2018/9/5")).toDateString()); //Wed Sep 05 2018
console.log(new Date(Date.parse("2018/9/5")).toTimeString()); //00:00:00 GMT+0800 (中国标准时间)
console.log(new Date(Date.parse("2018/9/5")).toLocaleDateString()); //2018-9-5
console.log(new Date(Date.parse("2018/9/5")).toLocaleTimeString()); //00:00:00
console.log(new Date(Date.parse("2018/9/5")).toUTCString()); //Tue, 04 Sep 2018 16:00:00 GMT
console.log(new Date(Date.parse("2018/9/5")).valueOf()); //1536076800000
```
　　19、日期/时间组件方法：UTC日期指的是在没有时区偏差的情况下(将日期转换为GMT时间)的日期值。  
```
var _date = new Date(Date.parse("2018/9/5"));
console.log(_date); //2018-09-04T16:00:00.000Z

console.log(_date.getTime()); //1536076800000 返回表示日期的毫秒数，与valueOf()方法返回值相同
_date.setTime(1536076900000); //以毫秒数设置日期，会改变整个日期
console.log(_date); //2018-09-04T16:01:40.000Z

console.log(_date.getFullYear()); //2018
console.log(_date.getUTCFullYear()); //2018
_date.setFullYear(2017); //参数必需是4位数字
console.log(_date); //2017-09-04T16:01:40.000Z
_date.setUTCFullYear(2017); //参数必需是4位数字
console.log(_date); //2017-09-04T16:01:40.000Z

console.log(_date.getMonth()); //8 月份为0-11
console.log(_date.getUTCMonth()); //8 月份为0-11
_date.setMonth(7); //值必需大于等于0，超过11则增加年份
console.log(_date); //2017-08-04T16:01:40.000Z
_date.setUTCMonth(7); //值必需大于等于0，超过11则增加年份
console.log(_date); //2017-08-04T16:01:40.000Z

console.log(_date.getDate()); //5 天数1-31
console.log(_date.getUTCDate()); //4
_date.setDate(4); //值必需大于等于1，超过该月中应有的天数则增加月份
console.log(_date); //2017-08-03T16:01:40.000Z
_date.setUTCDate(3); //值必需大于等于1，超过该月中应有的天数则增加月份
console.log(_date); //2017-08-03T16:01:40.000Z

console.log(_date.getDay()); //5 返回星期几，0表示星期日，6表示星期六 ？？
console.log(_date.getUTCDay()); //4 返回星期几，0表示星期日，6表示星期六

console.log(_date.getHours()); //0 小时数0-23
console.log(_date.getUTCHours()); //16 小时数0-23
_date.setHours(8); //值必需大于等于0，超过23则增加天数
console.log(_date); //2017-08-04T00:01:40.000Z
_date.setUTCHours(8); //值必需大于等于0，超过23则增加天数
console.log(_date); //2017-08-04T08:01:40.000Z

console.log(_date.getMinutes()); //1 分钟数0-59
console.log(_date.getUTCMinutes()); //1 分钟数0-59
_date.setMinutes(30); //值必需大于等于0，超过59则增加小时数
console.log(_date); //2017-08-04T08:30:40.000Z
_date.setUTCMinutes(30); //值必需大于等于0，超过59则增加小时数
console.log(_date); //2017-08-04T08:30:40.000Z

console.log(_date.getSeconds()); //40 秒数0-23
console.log(_date.getUTCSeconds()); //40 秒数0-23
_date.setSeconds(70); //值必需大于等于0，超过59则增加分钟数
console.log(_date); //2017-08-04T08:31:10.000Z
_date.setUTCSeconds(70); //值必需大于等于0，超过59则增加小时数
console.log(_date); //2017-08-04T08:31:10.000Z

console.log(_date.getTimezoneOffset()); //-480 返回本地时间与UTC时间相差的分钟数，在某地进入夏令时时值有变化

//以下代码报错 ？？
console.log(_date.getMilliSeconds()); //毫秒数
console.log(_date.getUTCMilliSeconds()); //毫秒数
_date.setMilliSeconds();
console.log(_date);
_date.setUTCMilliSeconds();
console.log(_date);
```
　　20、RegExp类型：ECMAScript通过RegExp类型来支正则表达式。  
　　正则表达式的匹配模式支持下列3个标志：  
(1) g: 全局(global)模式，即模式将被应用于所有字符串；  
(2) i: 不区分大小写(case-insensitive)模式；  
(3) m: 多行(multiline)模式，即在达一行文本末尾时还会继续查找下一行中是否存在与模式匹配的项。  
　　模式中使用的所有元字符都必须转义。元字符包括：( [ { \\ ^ $ | ) ? * + . ] }。（两个反斜杠的第一个是转义符，用于看本文档生成的内容，与实际内容无关）  
　　创建正则表达式的方式有两种：字面量形式、构造函数。在构造函数中，在某些情况下需要对字符串进行双重转义，所有元字符都必须双重转义。  
```
//pattern部分可以是任何正则表达式，可包含字符类、限定符、分组、向前查找、引用
//每个正则表达式都可带一个或多个flags，用以表明正则表达式的行为
var expression = / pattern / flags;

//匹配第一个"bat"或"cat"，不区分大小写
var pattern1 = / [bc]at/i //字面量形式
var pattern2 = new RegExp("[bc]at", "i"); //构造函数 参数：要匹配的字符串模式 可选的标志字符串

var re = null, i;
for (var i = 0; i < 10; i++) {
    re = /cat/g; //在ECMAScript3中，多次循环的re共享同一个RegExp实例，因而下一次的执行是在上一次的基础上的；在ECMAScript5中，每次循环都创建新的实例
}
for (var i = 0; i < 10; i++) {
    re = new RegExp("cat", "g"); //在ECMAScript3和ECMAScript5中，每次循环都创建新的实例
}
```
　　21、RegExp实例属性：布尔值global，表示是否设置了g标志；布尔值ignoreCase表示是否设置了i标志；整数lastIndex表示开始搜索下一个匹配项的字符位置，从0算起；布尔值multiline表示是否设置了m标志；正则表达式的字符串表示，source，按照字面量形式而非传入构造函数中的字符串模式返回。  
```
console.log(pattern1.global); //false
console.log(pattern1.ignoreCase); //true
console.log(pattern1.multiline); //false
console.log(pattern1.lastIndex); //0
console.log(pattern1.source); //[bc]at

var text = "cat, bat, sat, fat";
var a = /.at/i;
var b = /.at/g;
```
　　22、RegExp实例方法：捕获组exec()：一个参数：要应用模式的字符串。返回包含第一个匹配项信息的数组或null。返回的数组是Array实例，并额外包含表示匹配现在字符串中的位置的index属性和表示应用正则表达式的字符串的input属性。对该方法而言，即使在模式中设置了全局标志，它每次也只会返回一个匹配项。不设置全局标志，在同一个字符串上多次调用方法将始终返回第一个匹配项的信息，lastIndex值不变；设置全局标志，每次调用方法都会在字符串中继续查找新匹配项，lastIndex值不变在每次调用方法后都会增加。检测字符串是否与模式匹配test()：一个字符串参数。模式与参数匹配则返回true，否则返回false。只想知道目标字符串是否与某个模式匹配、但不需要知道其文本内容，只想知道输入是否有效等则使用此方法。toLocaleString()和toString()方法返回正则表达式的字面量，与创建正则表达式的方式无关。valueOf()方法返回正则表达式本身。  
```
var _exec1 = a.exec(text);
console.log(_exec1.index); //0
console.log(_exec1[0]); //cat
console.log(a.lastIndex); //0
var _exec2 = b.exec(text);
console.log(_exec2.index); //0
console.log(_exec2[0]); //cat
console.log(b.lastIndex); //3
console.log(_exec2.index); //0
console.log(_exec2[0]); //cat
console.log(b.lastIndex); //3

console.log(a.test("cat")); //0

console.log(a.toString()); ///.at/i
console.log(a.toLocaleString()); ///.at/i
console.log(a.valueOf()); ///.at/i
```
　　23、RegExp构造函数属性：最近一次要匹配的字符串input(\$_)，最近一次的匹配项lastMatch(\$&)，最近一次匹配的捕获组(\$+)，input字符串中lastMatch之前的文本leftContext(\$`)，是否所有表达式都使用多行模式multiline(\$*),input字符串中lastMatch之后的文本rightContext(\$')。它们使用于作用域中的所有正则表达式，并且基于所执行的最近一次正则表达式操作而变化。括号内的是短属性名，（反斜杠是转义符，用于看本文档生成的内容，与实际内容无关），但由于大多不是有效的ECMAScript标识符，因此需要通过方括号语法来访问它们。使用这些属性可以从exec()或test()执行的操作中提取出更具体的信息。但并不是所有浏览器都支持它们。除这几个属性外，还有多达9个用于存储捕获组的构造函数属性，访问语法是RegExp.$1，1可以换成2-9，分别用于存储第一到第九个匹配的捕获组，在调用exec()或test()方法时，这些属性会被自动填充。  
```
//创建一个模式：匹配任何一个字符后跟hort，而且把第一个字符放在了一个捕获组中
var text = "this has been a short summer";
var pattern = /(.)hort/g;
if (pattern.test(text)) {
    console.log(RegExp.input); //this has been a short summer
    console.log(RegExp.leftContext); //this has been a 注意最后还有一个空格
    console.log(RegExp.rightContext); // summer 注意最前面有一个空格
    console.log(RegExp.lastMatch); //short
    console.log(RegExp.lastParen); //s
    console.log(RegExp.multiline); //undefined
}
if (pattern.test(text)) {
    console.log(RegExp.$); //this has been a short summer
    console.log(RegExp["$`"]); //this has been a 注意最后还有一个空格
    console.log(RegExp["$'"]); // summer 注意最前面有一个空格
    console.log(RegExp["$&"]); //short
    console.log(RegExp["$+"]); //s
    console.log(RegExp["$*"]); //undefined
}
var pattern = /(..)or(.)/g;
if (pattern.test(text)) {
    console.log(RegExp.$1); //sh
    console.log(RegExp.$2); //t
    console.log(RegExp.$9); //  空
}
```
　　24、模式的局限性（不支持的特性）：匹配字符串开始和结尾的\A和\Z锚、向后查找（lookbehind）、并集和交集、原子组（atomic grouping）、Unicode支持（单个字符除外，如\uFFF）、命名的捕获组、s（single，单行）和x（free-spacing，无间隔）匹配模式、条件匹配、正则表达式注释。  
　　25、Function类型：实际上是对象。每个函数都是Function类型的实例，而且都与其他引用类型一样具有属性和方法。函数名实际上是一个指向函数对象的指针，不会与某个函数绑定。因此一个值是函数的变量，也可以被复制变量值给其他变量，即一个函数可能会有多个名字。  
```
//函数声明语法定义函数
//率先解析函数声明，并使其在执行任何代码之前可用（可以访问）
function func1(num1, num2) {
    return num1 + num2;
}
//函数表达式定义函数
//等到解析器执行到它所在的代码行，才会真正被解释执行
var func2 = function(num1, num2) {
    return num1 + num2;
};
//Function构造函数定义函数，不建议使用
//解析两次代码：第一次解析常规ECMAScript代码，第二次解析传入构造函数中的字符串
var func3 = new Function("num1", "num2", "return num1 + num2");

var func4 = func1;
console.log(func4(10, 10)); //20
func1 = null; //切断func1与函数的联系
console.log(func4(10, 10)); //20 即使func1与函数无关了，但func4也还是指向函数
```
　　26、没有重载：在书3.7.2，文档chapter3的30中简单提到了没有重载的概念。上面讲到，Function的本质是对象，因而将函数名想象为指针，那么，当定义了一个变量，变量指向一个函数，而对这个变量再次声明一个同名函数，那么这个变量就指向这个新的同名函数，而与旧的函数无关了。前面也提到过如果模拟函数重载：定义一个没有明确指定参数的函数，获取函数内置参数arguments的长度或内容，使用switch语句或者if语句进入对应的条件。  
　　函数本身也可以作为值来使用，因此它不仅可以像传递参数一样把一个函数传递给另一个函数（即访问函数的指针而不执行函数，必须去掉函数名后面的括号），也可以将一个函数作为另一个函数的结果返回。  
　　27、在函数内部，有两个特殊的对象：arguments和this。还有另一个属性caller。
　　arguments在前面提到过，它是一个类数组对象，包含着传入函数中的所有参数，它还有一个名叫callee的属性，这是一个指针，指向拥有这个arguments对象的函数。在使用递归方法写函数时，返回值为函数，这时arguments.callee()就可以代替函数名，因而当函数名修改后不用再修改函数内容。严格模式下会报错。  
```
//递归方法定义阶乘函数
function factorial1(num) {
    if (num <= 1) {
        return 1;
    } else {
        return num * factorial1(num - 1)
    }
}
function factorial2(num) {
    if (num <= 1) {
        return 1;
    } else {
        //callee指向拥有这个arguments对象的函数，此处arguments.callee()即本函数factorial2
        //如果重新定义这个函数(即不叫factorial2)，也不需要修改内容，而正常完成递归调用
        return num * arguments.callee(num - 1);
    }
}
```
　　this引用的是函数据以执行的环境对象，如当在网页的全局作用域中调用函数时，this对象引用的就是window。  
```
function sayColor() { //在全局作用域中定义函数
    console.log(this.color);
}

color = "red"; //在全局作用域中定义color
sayColor(); //red 在全局作用域中调用函数，this引用全局对象，如果是浏览器，全局对象为window，this.color即为window.color

var obj = {color: "blue"}; //在obj这个对象中定义color
obj.sayColor = sayColor; //将函数赋给对象obj
obj.sayColor(); //blue 在obj作用域中调用函数，this引用obj对象，this.color即为obj.color
```
　　caller：函数对象的属性，保存着调用当前函数的函数的引用。如果是在全局作用域中调用当前函数，值为null。arguments.caller始终返回undefined，而在严格模式下报错。严格模式下也不能为caller属性赋值。在严格模式下这样设置是为了加强这门语言的安全性，这样第三方代码就不能在相同的环境里窥视其他代码了。  
```
function a(arg) {
    b();
}
function b() {
        //console.log(b.caller); //[Function: a]
        console.log(arguments.callee.caller); //[Function: a]
        console.log(arguments.caller); //undefined
    }
a();
```
　　28、函数的属性和方法：属性length和prototype、非继承而来的方法apply()和call()、新定义的bind()方法。  
　　length: 函数希望接收的命名参数的个数，即定义函数时的参数个数。  
```
console.log(a.length); //1
console.log(b.length); //0
```
　　prototype：保存ECMAScript中的引用类型的所有实例方法的真正所在。在创建自定义引用类型及实现继承时，其作用极为重要。且在ECMAScript5中，proto属性不可枚举，因此使用for-in无法发现。  
　　apply()和call()：在特定的作用域中调用函数，实际上等于设置函数体内this对象的值。apply()接收两个参数：在其中运行函数的作用域、参数数组。第二个参数可以是Array的实例，也可以是arguments对象。call()方法接收的参数：this值、参数1、参数2...，在使用call()方法时，传递给函数的参数必须逐个列举出来。实际上，它们真正的用武之地是扩充函数赖以运行的作用域，这样，对象就不需要与方法有任何的耦合关系。  
```
function sum(num1, num2) {
    return num1 + num2;
}
function applySum1(num1, num2) {
    //传入this值作为this值, 全局作用域中调用函数, 则浏览器中this是window对象
    return sum.apply(this, arguments); //传入arguments对象
}
function applySum2(num1, num2) {
    return sum.apply(this, [num1, num2]); //传入数组
}
console.log(applySum1(1, 2)); //3
console.log(applySum1(1, 2)); //3

function callSum1(num1, num2) {
    return sum.call(this, arguments); //传入arguments对象
}
function callSum2(num1, num2) {
    return sum.call(this, [num1, num2]); //传入数组
}
function callSum3(num1, num2) {
    return sum.call(this, num1, num2); //传入每个参数
}
console.log(callSum1(1, 2)); //[object Arguments]undefined
console.log(callSum2(1, 2)); //1,2undefined
console.log(callSum3(1, 2)); //3

function sayColor() { //在全局作用域中定义函数
    console.log(this.color);
}
color = "red"; //在全局作用域中定义colorsayColor，在浏览器中则是window中定义
var obj = {color: "blue"}; //在obj这个对象中定义color
sayColor.apply(this); //red
sayColor.apply(obj); //blue
sayColor.call(this); //red
sayColor.call(obj); //blue
```
　　bind(): 创建一个函数的实例，其this值会被绑定到传给bind()函数的值。  
```
var objC = sayColor.bind(obj);
objC(); //blue 在全局作用域中调用该函数，返回的依旧是obj作用域的结果
```
　　toString()、toLocaleString()、valueOf()：因浏览器不同而返回不同格式的函数代码。  
　　29、基本包装类型：为了便于操作基本类型值，ECMAScript还提供了3个特殊的引用类型：Boolean/Number/String。实际上，当我们定义一各基本类型值时，后台会创建一个对应的基本包装类型的对象，从而让我们能够调用一些方法来操作这些数据，但这个对象只存在于创建基本类型值的瞬间，然后立刻被销毁，因此我们不能为基本类型值添加属性和方法。  
```
//在这句代码执行的瞬间实际上是str = new String("string text"),但当执行后面的代码时，这个对象被销毁
var str = "string text";
```
　　可以显示地调用Boolean/Number/String来创建基本包装类型的对象，但这种做法很容易让人分不清自己在处理基本类型还是引用类型的值，因此只有在绝对必要时才这样做。  
　　30、Boolean类型的实例重写了valueOf()方法，返回基本类型值true或false；重写了toString()方法，返回字符串"true"和"false"。  
```
var val = false;
console.log(val);  //false
console.log(typeof val); //boolean
console.log(val instanceof Boolean); //false
console.log(val instanceof Object); //false
console.log(val && true); //false
console.log(true && val); //false

var boolVal = Boolean(val); //转型函数
console.log(boolVal); //false
console.log(typeof boolVal); //boolean
console.log(boolVal instanceof Boolean); //false
console.log(boolVal instanceof Object); //false
console.log(boolVal && true); //false
console.log(true && boolVal); //false

var objVal = new Boolean(val); //构造函数
console.log(objVal); //[Boolean: false]
console.log(typeof objVal); //object
console.log(objVal instanceof Boolean); //true
console.log(objVal instanceof Object); //true
console.log(objVal && true); //true 布尔表达式中所有对象都会被转换为true
console.log(true && objVal); //[Boolean: false]
```
　　31、Number类型的实例重写了valueOf()方法，返回对象表示的基本类型的数值；重写了toString()和toLocaleString()方法，返回字符串形式的数值。  
　　除了继承的方法外，Number类型还提供了一些用于将数值格式化为字符串的方法：toFixed()、toExponential()和toPrecision()。  
```
var num = 10;

//toString()返回字符串：参数(可选)：几进制
console.log(num.toString()); //10
console.log(num.toString(2)); //1010
console.log(num.toString(8)); //12
console.log(num.toString(10)); //10
console.log(num.toString(16)); //a

//toFixed()按指定的小数位返回数值的字符串表示：参数：小数位数
console.log(num.toFixed(2)); //10.00
console.log(10.005.toFixed(2)); //10.01 不同浏览器舍入规则不同

//toExponential()格式化数值，返回以指数表示法表示的数值的字符串形式：参数(可选)：指定输出结果中的小数位数
console.log(num.toExponential()); //1e+1
console.log(num.toExponential(2)); //1.00e+1

//toPrecision()得到数值的最合适的表示格式：参数：数值的所有数字的位数（不包含指数部分）
console.log(num.toPrecision()); //10
console.log(num.toPrecision(1)); //1e+1
console.log(num.toPrecision(3)); //10.0

```
　　直接实例化Number类型及显示创建Boolean对象：在使用typeof和instanceof操作符测试基本类型数值与引用类型数值时，得到的结果完全不同。  
```
var val = 0;
console.log(val);  //0
console.log(typeof val); //number
console.log(val instanceof Number); //false
console.log(val instanceof Object); //false
console.log(val && true); //0
console.log(true && val); //0

var numVal = Number(val); //转型函数
console.log(numVal); //0
console.log(typeof numVal); //number
console.log(numVal instanceof Number); //false
console.log(numVal instanceof Object); //false
console.log(numVal && true); //0
console.log(true && numVal); //0

var objVal = new Number(val); //构造函数
console.log(objVal); //[Number: 0]
console.log(typeof objVal); //object
console.log(objVal instanceof Number); //true
console.log(objVal instanceof Object); //true
console.log(objVal && true); //true
console.log(true && objVal); //[Number: 0]
```
　　32、String类型：是字符串的对象包装类型。String对象的方法也可以在所有基本的字符串值中访问到。继承的valueOf()、toString()和toLocaleString()方法都返回对象所表示的基本字符串值。String类型的每个实例都有一个length属性，表示字符串中包含多少个字符，并且即使字符串中包含双字节字符（不是占一个字节的ASCII字符），每个字符也仍然算一个字符。  
　　33、字符方法：访问字符串中特定字符的方法：charAt()和charCodeAt()。参数：基于0的字符位置。其中，charAt()方法以单字符字符串的形式返回给定位置的哪个字符（ECMAScript中没有字符类型）。
```
var str = "hello";
console.log(str.charAt(1)); //e 字符串中位置1的字符
console.log(str.charCodeAt(1)); //101 字符串中位置1的字符编码
console.log(str[1]); //e 不是每种浏览器都支持该方法
```
　　34、基于子字符串创建新字符串的方法：slice()、substr()、substring()。参数：起始位置(含)，结束位置(不含)/返回的字符个数(substr)。如果第二个参数为空则输出到字符串结束。这些方法都不改变原字符串。  
序号 | 方法 | slice() | substr() | substring()
---- | ---- | ---- | ---- | ----
0 | 功能 | 基于子字符串创建新字符串 | 基于子字符串创建新字符串 | 基于子字符串创建新字符串
0.1 | 返回值 | 一个基本类型的子字符串值 | 一个基本类型的子字符串值 | 一个基本类型的子字符串值
0.2 | 对原数组的影响 | 不影响 | 不影响 | 不影响
0.3 | 参数1 | 起始位置(含) | 起始位置(含) | 起始位置(含)或结束位置(不含)
0.4 | 参数2 | 结束位置(不含) | 返回的字符个数 | 起始位置(含)或结束位置(不含)
1 | 有1个参数时输出值 | 起始位置(含)到字符串结束 | 起始位置(含)到字符串结束 | 起始位置(含)到字符串结束
2 | 有2个参数时输出值 | 根据参数输出 | 根据参数输出 | 根据参数输出
2.1 | 输出值起始位置 | 参数1 |  参数1 | 参数1和参数2中较小数
2.2 | 输出值结束位置 | 参数2 - 1 |  参数1 + 参数2 - 1 |  参数1和参数2中较大数 - 1
3 | 参数1为负数时被转换的值 | 参数1 + str.length | 参数1 + str.length | 0
4 | 参数2为负数时被转换的值 | 参数2 + str.length | 0 | 0
5 | 2个参数都为0 | 空字符串 | 空字符串 | 空字符串

```
var str = "helloya"; //length = 7
console.log(str.concat(" word", "!")); //helloya word!
console.log(str + " word" + "!"); //helloya word!

console.log(str.slice(1)); //elloya 参数：起始位置(含)  输出起始位置到结束
console.log(str.substr(1)); //elloya 参数：指定字符串的起始位置(含)  输出起始位置到结束
console.log(str.substring(1)); //elloya 参数：指定字符串的起始位置(含)  输出起始位置到结束

console.log(str.slice(1, 3)); //el 参数：起始位置(含)，结束位置(不含)，以第一个参数为开始位置，第二个参数为结束位置
console.log(str.substr(1, 3)); //ell 参数：起始位置(含)，返回的字符个数
console.log(str.substring(1, 3)); //el 参数：指定字符串的起始位置，结束位置(不含)，以较小数为开始位置，较大数为结束位置

console.log(str.slice(-1)); //a 参数值被转换为：参数+length，此处即为-1+7=6，输出该位置到结束
console.log(str.substr(-1)); //a 第一个参数值被转换为：参数+length，此处即为-1+7=6，输出该位置到结束
console.log(str.substring(-1)); //helloya 第一个参数被转换为0，输出该位置到结束，即返回全部字符串

console.log(str.slice(1, -3)); //ell 第二个参数值被转换为：参数+length，此处即为-3+7=4
console.log(str.substr(1, -3)); // 空字符串 第二个参数值被转换为0，即返回包含0个字符的字符串
console.log(str.substring(1, -3)); //h 第二个参数值被转换为0，以较小数为开始位置，较大数为结束位置，则等价于(0, 1)

console.log(str.slice(-1, -3)); // 空字符串 被转换为(-1+7, -3+7)=(6, 4)，开始位置大于结束位置，返回空字符串
console.log(str.substr(-1, -3)); // 空字符串 第二个参数值被转换为0，即返回包含0个字符的字符串，不用考虑第一个参数
console.log(str.substring(-1, -3)); // 空字符串 两个参数都被转换为0，则返回空字符串

console.log(str.slice(0, 0)); // 空字符串
console.log(str.substr(0, 0)); // 空字符串
console.log(str.substring(0, 0)); // 空字符串
```
　　35、字符串位置方法：从字符串中查找子字符串的方法：indexOf()和lastIndexOf()。返回字符串位置或-1。第一个参数是要查找的子字符串，第二个参数 是指定的开始搜索的位置(可选)。如果第二个参数在循环中依次递增，则可以找到字符串中所有匹配的子字符串。  
```
console.log(str.indexOf("l")); //2 字符"l"第一次出现的位置
console.log(str.lastIndexOf("l")); //3 字符"l"最后一次出现的位置
console.log(str.indexOf("l", 4)); //-1 从第4个位置开始向后搜索
console.log(str.lastIndexOf("l", 2)); //2 从第2个位置开始向前搜索

//找到字符串中所有匹配的子字符串
var index = str.indexOf("l"); //找到第一次出现字符的位置
var arr_index = [];
while(index > -1) { //最后一个次搜索结果是未找到该字符，返回-1，跳出循环
    arr_index.push(index);
    index = str.indexOf("l", index + 1); //这一次的搜索是从上一次的搜索结果的下一个字符位置开始的
}
console.log(arr_index); //[ 2, 3 ]
```
　　36、trim()方法：创建字符串的副本，删除前置及后缀的所有空格，然后返回结果，不改变原字符串。Firefox3.5+、Safari5+、Chrome8支持非标准的trimLeft()和trimRight()方法。  
```
var str = "   hel  lo   ";
console.log(str.trim()); //"hel  lo" 删除左右空格
console.log(str.trimLeft()); //"hel  lo   " 删除左空格
console.log(str.trimRight()); //"   hel  lo" 删除右空格
```
　　37、字符串大小写转换：toLowerCase()、toLocaleLowerCase()、toUpperCase()、toLocaleUpperCase()。其中，第一个和第三个方法是借鉴自Java的同名方法，是两个经典的方法；另外两个方法是针对特定地区的实现。对少数语言来说，会为Unicode大小写转换应用特殊规则，因此必须使用针对地区的方法来保证正确的转换。一般来说，在不知道自己的代码将在哪种语言环境中运行的情况下，还是使用针对地区的方法更稳妥一些。  
```
var str = "hello word";
console.log(str.toLowerCase()); //hello word
console.log(str.toLocaleLowerCase()); //hello word
console.log(str.toUpperCase()); //HELLO WORD
console.log(str.toLocaleUpperCase()); //HELLO WORD
var str = "HELLO WORD";
console.log(str.toLowerCase()); //hello word
console.log(str.toLocaleLowerCase()); //hello word
console.log(str.toUpperCase()); //HELLO WORD
console.log(str.toLocaleUpperCase()); //HELLO WORD
```
　　38、在字符串中匹配模式的方法：
　　match()：查找字符串位置。在字符串上调用这个方法，本质上与调用RegExp的exec()方法相同（见上文6.3），它只接受一个参数：一个正则表达式或一个RegExp对象。  
```
var text = "cat, bat, sat, fat";
var pattern = /.at/;
//与pattern.exec(text)相同
var matches = text.match(pattern);
console.log(matches.index); //0
console.log(matches[0]); //cat
console.log(pattern.lastIndex); //0
```
　　search()：查找字符串位置。参数唯一：一个正则表达式或一个RegExp对象。返回字符串中第一个匹配项的索引，如果没有找到则返回-1。始终从字符串开头向后查找。  
```
console.log(text.search(/at/)); //1
console.log(text.search("at")); //1
```
　　replace()：替换字符串。参数：一个正则表达式或一个RegExp对象（这个字符串不会被转换成正则表达式）、一个字符串或者一个函数。  
　　如果第一个参数是字符串，则只会替换第一个子字符串。如果想要替换所有子字符串，则只能提供一个正则表达式，且指定全局标志g。  
　　如果第二个参数是字符串，那么还可以使用一些特殊的字符序列，将正则表达式操作得到的值插入到结果字符串中。$$：$。$&：匹配整个模式的子字符串，与RegExp.lastMatch的值相同。$'：匹配的子字符串之前的子字符串，与RegExp.leftContext的值相同。$`：匹配的子字符串之后的子字符串，与RegExp.rightContext的值相同。$n：匹配第n个捕获组的子字符串，其中n等于0-9，如$1是匹配第一个捕获组的子字符串，如果正则表达式中没有定义捕获组，则使用空字符串。$nn：匹配第nn个捕获组的子字符串，其中nn等于01-99，如$01是匹配第一个捕获组的子字符串，如果正则表达式中没有定义捕获组，则使用空字符串。  
　　第二个参数还可以是一个函数。在只有一个匹配项（即与模式匹配的字符串）的情况下，会向这个函数传递3个参数：模式的匹配项、模式匹配项在字符串中的位置、原始字符串。在正则表达式中定义了多个捕获组的情况下，传递给函数的参数依次是：模式的匹配项、第一个捕获组的匹配项、第二个捕获组的匹配项……，但最后两个参数仍然分别是模式的匹配项在字符串中的位置和原始字符串。  
```
console.log(text.replace("at", "ond")); //cond, bat, sat, fat
console.log(text.replace(/at/, "ond")); //cond, bat, sat, fat
console.log(text.replace(/at/g, "ond")); //cond, bond, sond, fond

console.log(text.replace(/(.at)/g, "word ($1)")); //word (cat), word (bat), word (sat), word (fat)

function htmlEscape(text) {
    return text.replace(/[<>"&]/g, function(match, pos, originalText) {
        switch (match) {
            case "<":
                return "&lt;";
            case ">":
                return "&gt;";
            case "&":
                return "&amp;";
            case "\"":
                return "&quot;";
        }
    });
}
console.log(htmlEscape("<p class=\"greeting\">Hello world!</p>")); //&lt;p class=&quot;greeting&quot;&gt;Hello world!&lt;/p&gt;
```
　　split()：基于指定的分隔符将一个字符串分割成多个子字符串，并将结果放在一个数组中。分隔符可以是字符串，也可以是一个RegExp对象（这个方法不会将字符串看成正则表达式）。可选的第二个参数用于指定的大小，以便确保返回的数组不会超过既定大小。不同浏览器对参数中的正则表达式的支持不同。  
```
var color = "red, blue, green, yellow";
console.log(color.split(",")); //[ 'red', ' blue', ' green', ' yellow' ]
console.log(color.split(",", 2)); //[ 'red', ' blue' ]
console.log(color.split(/[^\,]+/)); //[ '', ',', ',', ',', '' ] 获取包含逗号字符的数组 首尾出现了空字符串是由于通过正则表达式指定的分隔符出现在了字符串的开头和末尾
```
　　 localeCompare()：比较两个字符串，并返回下列值中的一个：
如果字符串在字母表中应该排在字符串参数之前，则返回一个负数（大多数情况下是-1，具体的值要视实现而定）；  
如果字符串等于字符串参数，则返回0；
如果字符串在字母表中应该排在字符串参数之后，则返回一个正数（大多数情况下是1，具体的值同样要视实现而定）。
　　 实现所支持的地区（国家和语言）决定了localeCompare()方法的行为。例如，美国以英语作为ECMAScript实现的标准语言，因此localeCompare()就是区分大小写的，于是大写字母在字母表中排在小写字母前面就成了一项决定性的比较规则，但在其他地区可能不是这种情况。
```
var str = "y";
console.log(str.localeCompare("b")); //1
console.log(str.localeCompare("y")); //0
console.log(str.localeCompare("z")); //-1
```
　　fromCharCode()：接收一个或多个字符编码，然后把它们转换成一个字符串。它是String构造函数本身的静态方法。从本质上看，这个方法与实例方法charCodeAt()执行的是相反的操作。  
```
console.log(String.fromCharCode(104, 101, 108, 108, 111)); //hello
```
　　39.单体内置对象：由ECMAScript实现提供的、不依赖于宿主环境的对象，这些对象在ECMAScript程序执行之前就已经存在。即开发人员不必显示地实例化内置对象，因为它们已经实例化了。例如前面的Object、Array和String。除此之外，还有两个单体内置对象：Global和Math。  
　　40、Global对象：不属于任何其他对象的属性和方法，最终都是它的属性和方法。事实上，没有全局变量或全局函数，所有全局作用域中定义的属性和函数，都是Global对象的属性。例如，isNaN()、ifFinite()、parseInt()、parseFloat()。除此之外，它还包含其他一些方法。  
　　41、URI编码方法：encodeURI()和encodeURIComponent()方法可以对URI(Uniform Resource Identifiers，通用资源标识符)进行编码，以便发送给浏览器。有效的URI中不能包含如空格的某些字符，而这两个URI编码方法用特殊的UTF-8编码替换所有无效字符，从而让浏览器能够接受和理解。其中，encodeURI()主要用于整个URI（如http://www.wrox.com/illegal value.html），而encodeURIComponent()主要用于对URI中的某一段（如前面URI中的illegal value.htm）进行编码。主要区别在于：前者不会对本身属于URI的特殊字符进行编码，例如冒号、正斜杠、问号和井号；而encodeURIComponent()则会对它发现的任何非标准字符进行编码。  
```
var uri = "http://www.wrox.com/illegal value.html";
console.log(encodeURI(uri)); //http://www.wrox.com/illegal%20value.html 除了空格之外的字符其他都不变，空格被替换成了%20
console.log(encodeURIComponent(uri)); //http%3A%2F%2Fwww.wrox.com%2Fillegal%20value.html 替换所有非字母数字字符

var uri = "http%3A%2F%2Fwww.wrox.com%2Fillegal%20value.htm%23start";
console.log(decodeURI(uri)); //http%3A%2F%2Fwww.wrox.com%2Fillegal value.htm%23start 不对%23作处理是因为它表示的井字号#不是使用encodeURI()替换的
console.log(decodeURIComponent(uri)); //http://www.wrox.com/illegal value.htm#start 全部替换为原来的字符，但这个字符串并不是一个有效的URI
```
　　42、eval()：ECMAScript中最强大的方法。就像是一个完整的ECMAScript解析器。只接受一个参数，即要执行的ECMAScript(或JavaScript)字符串。当解析器发现代码中调用该方法时，它会将传入的参数当作实际的ECMAScript语句来解析，然后把结果插入到原位置。通过该方法执行的代码被认为是包含该次调用的执行环境的一部分，因此被执行的代码具有与该执行环境相同的作用域链，这意味着通过该方法执行的代码可以引用在包含环境中定义的变量。但严格模式下不可以访问定义在内部的变量，也不能为eval赋值。在执行用户输入数据的情况时，可能会存在代码注入（即恶意用户输入威胁站点或影城程序安全的代码）。  
```
eval("var a = 'hello';");
console.log(a); //a定义在eval()内，但外部依旧可以访问，但严格模式下报错
```
　　43、Global对象的属性：特殊值undefined、NaN/Infinity、所有原生引用类型的构造函数如Object和Function。且ECMAScript5明确禁止给三个特殊值赋值。  
属性 | 说明
---- | ----
undefined | 特殊值undefined
NaN | 特殊值NaN
Infinity | 特殊值Infinity
Object | 构造函数Object
Array | 构造函数Array
Function | 构造函数Function
Boolean | 构造函数Boolean
String | 构造函数String
Number | 构造函数Number
Date | 构造函数Date
RegExp | 构造函数RegExp
Error | 构造函数Error
EvalError | 构造函数EvalError
RangeError | 构造函数RangeError
ReferenceError | 构造函数ReferenceError
SyntaxError | 构造函数SyntaxError
TypeError | 构造函数TypeError
URIError | 构造函数URIError
　　44、window对象：ECMAScript没有明确指出如何直接访问Global对象，但Web浏览器都是将这个全局对象作为window对象的一部分加以实现的。因此在全局作用域中声明的所有变量和函数都成了window对象的属性。另一种取得Global对象的方法是使用下面的代码：代码创建了一个立即调用的函数表达式，返回this值，在没有明确指定this值的情况下，this值等于Global对象。像这样通过简单地返回this值来取得Global对象，在任何执行环境中都是可行的。  
```
var global = function() {
    return this;
}();
```
　　45、Match对象：保存数学公式和信息的公共位置。  
　　Match对象的属性：  
属性 | 说明
---- | ----
Math.E | 自然对数的底数，即常量e的值
Math.LN10 | 10的自然对数
Math.LN2 | 2的自然对数
Math.LOG2E | 以2为底e的对数
Math.LOG10E | 以10为底e的对数
Math.PI | π的值
Math.SQRT1_2 | 1/2的平方根(即2的平方根的倒数)
Math.SQRT2 | 2的平方根

```
//最大最小值
console.log(Math.min(1, 2, 3)); //1
console.log(Math.max(1, 2, 3)); //3
//查找数组中的最大最小值
console.log(Math.min.apply(Math, [1, 2, 3]));
console.log(Math.max.apply(Math, [1, 2, 3]));

//舍入方法
//向上舍入
console.log(Math.ceil(1.1)); //2
console.log(Math.ceil(1.5)); //2
console.log(Math.ceil(1.9)); //2
console.log(Math.ceil(-1.1)); //-1
console.log(Math.ceil(-1.5)); //-1
console.log(Math.ceil(-1.9)); //-1
//向下舍入
console.log(Math.floor(1.1)); //1
console.log(Math.floor(1.5)); //1
console.log(Math.floor(1.9)); //1
console.log(Math.floor(-1.1)); //-2
console.log(Math.floor(-1.5)); //-2
console.log(Math.floor(-1.9)); //-2
//四舍五入
console.log(Math.round(1.1)); //1
console.log(Math.round(1.5)); //2
console.log(Math.round(1.9)); //2
console.log(Math.round(-1.1)); //-1
console.log(Math.round(-1.5)); //-1
console.log(Math.round(-1.9)); //-2

//随机方法
//随机数：大于等于0小于1
Math.random();

//值 = Math.floor(Math.random() * 可能值的总数 + 第一个可能的值) 从某个整数范围内随机随机选择一个值
Math.floor(Math.random() * 10 + 1); //选择1到10之间的数值(总共10个可能的值:1-10共10个值, 第一个可能值是1)

//随机返回范围内的一个整数，参数：应该返回的最小值、最大值
function selectForm(lowerVal, upperVal) {
    var choices = upperVal - lowerVal + 1; //可能值的总数
    return Math.floor(Math.random() * choices + lowerVal);
}
selectForm(2, 10);

//随机取出数组中一个值
var arr = ["a", "b", "c", "d", "e"];
arr[selectForm(0, arr.length - 1)];
```
属性 | 说明
---- | ----
Math.abs(num) | 返回num的绝对值
Math.exp(num) | 返回Math.E的num次幂
Math.log(num) | 返回num的自然对数
Math.pow(num, power) | 返回num的power次幂
Math.sqrt(num) | 返回num平方根
Math.acos(x) | 返回x的反余弦值
Math.asin(x) | 返回x的反正弦值
Math.atan(x) | 返回x的反正切值
Math.atan2(y, x) | 返回y/x的反正切值
Math.cos(x, power) | 返回x的余弦值
Math.sin(x) | 返回x的正弦值
Math.tan(x) | 返回x的正切值
