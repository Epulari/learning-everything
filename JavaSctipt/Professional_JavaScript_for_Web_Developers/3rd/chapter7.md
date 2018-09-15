# 第七章 函数表达式
　　1、定义函数的方式：函数声明、函数表达式。  
　　2、函数声明重要特征之一：函数声明提升(function declaration hoisting)。即在执行代码之前会先读取函数声明。这意味着可以把函数声明放在调用它的语句后面。  
```
//执行函数
sayHi();
//使用函数声明声明函数
function sayHi() {
}

//非标准的name属性,这个属性的值永远等于跟在function关键字后面的标识符
console.log(sayHi.name);
```
　　3、使用函数表达式创建函数。函数表达式有几种不同的语法形式，下面是最常见的一种。这种情况下创建的函数叫做匿名函数(anonymous function)，因为function关键字后面没有标识符。匿名函数有时候也叫拉姆达函数。匿名函数的name属性是空字符串。函数表达式与其他表达式一样，在使用前必须先赋值，否则会报错。  
```
//执行函数
sayHi(); //报错

//使用函数表达式声明函数
var sayHi = function() {
}
```
　　4、递归：递归函数是在一个函数通过名字调用自身的情况下构成的。下面使用了三种方法来进行递归。  
```
//递归1：使用函数名进行递归
function factorial(num) {
    if (num <= 1) {
        return 1;
    } else {
        //使用函数名进行递归
        return num * factorial(num - 1);
    }
}

//递归2：使用函数内部变量属性进行递归
function factorial(num) {
    if (num <= 1) {
        return 1;
    } else {
        //arguments.callee是一个指向正在执行的函数的指针
        return num * arguments.callee(num - 1);
    }
}

//递归3：定义命名函数表达式，并将之赋值给变量
var factorial = (function f(num) {
    if(num < 1) {
        return 1;
    } else {
        return num * f(num -1);
    }
});

//对3种方法执行相同操作
var fac = factorial;
factorial = null; //切断名称与函数的连接
console.log(fac(4)); //递归1报错，递归2在严格模式下报错，递归3不报错
```
　　5、闭包：指有权访问另一个函数作用域中的变量的函数。创建闭包的常见方式，就是在一个函数内部创建另一个函数。  
　　先来复习一下作用域链：后台的每个执行环境都有一个表示变量的对象：变量对象。全局环境的变量对象始终存在。而像下面compare()函数这样的局部环境的变量对象，则只在函数执行的过程中存在。在创建函数时，会创建一个预先包含全局变量对象的作用域链，这个作用域链被保存在内部的[[Scope]]属性中。当调用该函数时，会为函数创建一个执行环境，然后通过复制函数的[[Scope]]属性中的对象构建起执行环境的作用域链。此后，又有一个活动对象（在此作为变量对象使用）被创建并被推入执行环境作用域链的前端。显然，作用域链本质上是一个指向变量对象的指针列表，它只引用但不实际包含变量对象。  
　　在下面代码中，在compare()执行环境的作用域链中，包含两个变量对象：compare()的活动对象(arguments、val1、val2)处于第1位，全局执行环境的变量对象(compare、result)处于第2位。  
```
function compare(val1, val2) {
    if(val1 < val2) {
        return -1;
    } else if(val1 > val2) {
        return 1;
    } else {
        return 0;
    }
}

var result = compare(5, 10);
```
　　一般来讲，当函数执行完毕后，局部活动对象就会被销毁，内存中仅保存全局作用域。但是，闭包的情况又有所不同。在另一个函数内部定义的函数会将包含函数（即外部函数）的活动对象添加到它的作用域链中。因此，下面的例子中，在createComparisonFunction()函数内部定义的匿名函数的作用域链中，实际上会包含外部函数createComparisonFunction()的活动对象。在匿名函数从createComparisonFunction()中被返回后，它的作用域链被初始化为包含createComparisonFunction()函数的活动对象和全局变量对象。这样，匿名函数就可以访问在createComparisonFunction()中定义的所有变量。更为重要的是，createComparisonFunction()函数在执行完毕后，其活动对象不会被销毁，因为匿名函数的作用域仍然在引用这个活动对象。换句话说，当createComparisonFunction()函数返回后，其执行环境的作用域链会被销毁，但它的活动对象仍然会留在内存中。直到匿名函数被销毁后，createComparisonFunction()的活动对象才会被销毁。  
　　首先，创建的比较函数被保存在变量compareNames中。而通过将compareNames设置为null解除该函数的引用，等价于通知垃圾回收例程将其清除。随着匿名函数的作用域链被销毁，其他作用域（除了全局作用域）也都可以安全地销毁了。  
　　由于闭包会携带包含它的函数的作用域，因此会比其他函数占用更多的内存。过度使用闭包可能会导致内存占用过多，因此只在绝对必要时再考虑使用闭包。  
```
//参数：一个属性名，根据这个属性名来进行判断
function createComparisonFunction(propertyName) {
    return function(object1, object2) { //匿名函数传给sort()方法，参数为要比较的值
        var value1 = object1[propertyName];
        var value2 = object2[propertyName];

        if(value1 < value2) {
            return -1;
        } else if (value1 > value2) {
            return 1;
        } else {
            return 0;
        }
    };
}

//创建函数
var compareNames = createComparisonFunction("name");
//调用函数
console.log(compareNames({name:"N"}, {name:"G"})); //1
//解除对匿名函数的引用，以便释放内存
compareNames = null;
```
　　6、闭包与变量：作用域链的这种配置机制导致闭包只能取得包含函数中任何变量的最后一个值。  
　　下面两个函数，第一个函数会返回一个函数数组，数组中的每个函数看似应该都返回自己的索引值，但实际上由于每个函数的作用域链中都保存着createFunctions()函数的活动对象，而当函数createFunctions()返回后，i的值是10，此时每个函数都引用着保存变量i的同一个变量对象，因此每个函数内部i的值都是10。  
　　在第二个函数中，修改了数组值的返回方式：定义一个匿名函数，并将立即执行该匿名函数的结果赋给数组。这个匿名函数有一个参数num，也就是最终的函数返回值。在调用每个匿名函数时，传入变量i，函数参数按值传递，则i的当前值会复制给参数num。而在这个匿名函数内部，又创建并返回了一个访问num的闭包。这样一来，result数组中的每个函数都有自己num变量的副本，因此就可以返回不同的值了。  
```
function createFunctions() {
    var result = new Array();
    for(var i = 0; i < 10; i++) {
        result[i] = function() {
            return i;
        };
    }
    return result;
}

function createFunctions() {
    var result = new Array();
    for(var i = 0; i < 10; i++) {
        result[i] = function(num) {
            return function() {
                return num;
            };
        }(i);
    }
    return result;
}

var b = createFunctions();
for(var i = 0; i < 10; i++) {
    console.log(b[i]());
}
//10 10 10 10 10 10 10 10 10 10
//0 1 2 3 4 5 6 7 8 9
```
　　7、闭包与this对象：匿名函数的执行环境具有全局性，因此其this对象通常指window（当然，在通过call()或apply()改变函数执行环境的情况下，this就会指向其他对象）。但有时候由于编写闭包的方式不同，这一点可能不会那么明显。  
　　为什么匿名函数取得的是全局作用域的this，而不是其包含作用域或者外部作用域的this对象呢？前面提到过，每个函数在被调用时都会自动取得两个特殊变量：this和arguments。内部函数在搜索这两个变量时，只会搜索到其活动对象为止，因此永远不可能直接访问外部函数中的这两个变量。不过，把外部作用域中的this对象保存在一个闭包能够访问到的变量里，就可以让闭包访问该对象了。  
```
//直接在node.js中运行可能为undefined，在浏览器中运行则为a
var name = "a";

var obj = {
    name: "b",
    getNameFunc: function() {
        return function() {
            return this.name;
        };
    }
};
console.log(obj.getNameFunc()); //a

var obj = {
    name: "b",
    getNameFunc: function() {
        //想访问作用域中的this和arguments对象时必须将该对象的引用保存到另一个闭包能够访问的变量中
        var that = this;
        return function() {
            return that.name;
        };
    }
};
console.log(obj.getNameFunc()()); //b

var obj = {
    name: "b",
    getNameFunc: function() {
        return this.name; //简单返回this.name的值
    }
};
console.log(obj.getNameFunc()); //b
//调用方法钱先加上了括号，虽然加上括号之后，就好像只是在引用一个函数，但this的值得到了位置
console.log((obj.getNameFunc)()); //b
//先执行赋值语句，再调用赋值后的结果，因为这个赋值表达式的值是函数本身，所以this的值不能得到维持
console.log((obj.getNameFunc = obj.getNameFunc)()); //a 需要在浏览器中运行
```
　　8、闭包与内存泄漏：前面提到过，IE9之前的版本对JScript对象和COM对象使用不同的垃圾收集例程，因此在IE中，如果闭包的作用域链中保存着一个HTML元素，那么意味着该元素将无法被销毁。  
　　下面例子中，第一个函数创建了一个作为element元素事件处理程序的闭包，而这个闭包则又创建了一个循环引用。由于匿名函数保存了一个对assignHandler()的活动对象的引用，因此就会导致无法减少element的引用数。只要匿名函数存在，element的引用数至少也是1，因此它所占用的内存就永远不会被回收。  
　　第二个函数对第一个函数作了修改：把element.id的一个副本保存在变量中，并且在闭包中引用该变量消除了循环引用。但仅仅这样还是不能解决内存泄漏的问题。因为闭包会引用包含函数的整个活动对象，而其中包含着element。即使闭包不直接引用element，包含函数的活动对象中也仍然会保存一个引用。因此，有必要把element变量设置为null。这样就能解除对DOM对象的引用，顺利地减少其引用数，确保正确回收其占用的内存。  
```
function assignHandler() {
    var element = document.getElementById("someElement");
    elememt.onclick = function() {
        console.log(elememt.id);
    };
}

function assignHandler() {
    var element = document.getElementById("someElement");
    var id = elememt.id;
    element.onclick = function() {
        console.log(id);
    };
    element = null;
}
```
　　9、JavaScript没有块级作用域的概念：这意味着，在块语句中定义的变量，实际上是在包含函数中而非语句中创建的。  
　　在下面函数中，即使错误地重新声明了同一个变量，也不会改变它的值。JavaScript不会告诉你是否多次声明了同一个变量，除了执行后续声明中的变量初始化外，只会对后续的声明视而不见。匿名函数可以用来模仿块级作用域并避免这个问题。
```
function a() {
    for(var i = 0; i < 10; i++) {
    }
    var i;
    console.log(i);
}
a();
```
　　10、匿名函数模仿块级作用域：以下代码定义并立即调用了一个匿名函数。将函数声明包含在一对圆括号里，表示它实际上是一个函数表达式。而仅随其后的另一对圆括号会立即调用这个函数。  
　　这种技术经常在全局作用域中被用在函数外部，从而限制向全局作用域中添加过多的变量和函数。一般来说，应该尽量少地向全局作用域中添加变量和函数。这种做法也可以减少闭包占用的内存问题，因为没有指向匿名函数的引用。只要匿名函数执行完毕，就可以立即销毁其作用域链了。  
```
(function() {
    //这里是块级作用域
})();
```
　　11、私有变量：严格来讲，JavaScript中没有私有成员的概念；所有对象属性都是公有的。但有私有变量的概念：任何在函数中定义的变量，都可以认为是私有变量，因为不能在函数的外部访问这些变量。私有变量包括函数的参数、局部变量、在函数内部定义的其他函数。  
　　12、特权方法(privileged method)：有权访问私有变量和私有函数的公有方法。有两种在对象上创建特权方法的方式：  
　　13、在构造函数中定义特权方法：特权方法作为闭包有权访问在构造函数中定义的所有变量和函数。在下面例子中，私有变量和私有函数只能通过特权方法来访问，创建MyObject的实例后，除了使用特权方法publicMethod()这一途径外，没有任何办法可以直接访问privateVariable和privateFunction()。  
　　缺点：每个实例都会创建同样一组新方法。使用静态私有变量来实现特权方法可以避免这个问题。  
```
//在构造函数中定义特权方法
function MyObject() {
    //私有变量和私有函数
    var privateVariable = 10;
    function privateFunction() {
        return false;
    }

    //特权方法
    this.publicMethod = function() {
        privateVariable++;
        return privateFunction();
    };
}

//利用私有和特权成员，可以隐藏不应该被直接修改的数据
function Person(name) {
    this.getName = function() {
        return name;
    };
    this.setName = function(val) {
        name = val;
    };
}
var person = new Person("N");
console.log(person.getName()); //N
person.setName("G");
console.log(person.getName()); //G
```
　　14、通过在私有作用域中定义私有变量或函数创建特权方法。在下面例子中，需要注意，这个模式在定义构造函数时并没有使用函数声明，而是使用了函数表达式。函数声明只能创建局部函数，但那并不是我们想要的。出于同样的原因，也没有在声明MyObject时使用var关键字。初始化未经声明的变量，总是会创建一个全局变量。因此，MyObject就成了一个全局变量，能够在私有作用域之外被访问到。  
　　这个模式与在构造函数中定义特权方法的主要区别：私有变量和函数是由实例共享的。由于特权方法是在原型上定义的，因此所有实例都使用同一个函数。而这个特权方法，作为一个闭包，总是保存着对包含作用域的引用。但以这种方式创建静态私有变量会因为使用原型而增进代码复用，但每个实例都没有自己的私有变量。  
```
(function() {
    //私有变量和私有函数
    var privateVariable = 10;
    function privateFunction() {
        return false;
    }

    //构造函数
    MyObject = function() {
    };

    //公有/特权方法
    MyObject.prototype.publicMethod = function() {
        privateVariable++;
        return privateFunction();
    };
})();

//例子
(function() {
    var name = ""; //静态的、由所有实例共享的属性

    Person = function(val) {
        name = val;
    };

    Person.prototype.getName = function() {
        return name;
    };
    Person.prototype.setName = function(val) {
        name = val;
    };
})();

var person1 = new Person("N");
console.log(person1.getName()); //N
person1.setName("G");
console.log(person1.getName()); //G

var person2 = new Person("M");
console.log(person1.getName()); //M
console.log(person2.getName()); //M
```
　　15、多查找作用域链中的一个层次，就会在一定程度上影响查找速度。这是使用闭包和私有变量的一个显眼的不足之处。  
　　16、模块模式(module pattern)：为单例创建私有变量和特权方法。单例(singleton)：只有一个实例的对象。在Web应用程序中，经常需要使用一个单例来管理应用程序级的信息。  
　　如果必须创建一个对象并以某些数据对其进行初始化，同时还要公开一些能够访问这些私有数据的方法，那么就可以使用模块模式。以这种模式创建的每个单例都是Object的实例，因为最终要通过一个对象字面量来表示它。但是一般情况下，单例都是作为全局对象存在的，我们不会把它传递给一个函数。因此，也没有什么必要使用instanceof操作符来检查其对象类型了。  
```
//单例
var singleton = {
    name: value,
    method: function() {
        //方法的代码
    }
};

//模块模式的特权方法
var singleton = function() {
    //私有变量和私有函数
    var privateVariable =10;
    function privateFunction() {
        return false;
    }

    //特权/公有方法和属性
    return {
        publicProperty: true,
        publicMethod: function() {
            privateVariable++;
            return privateFunction();
        }
    };
}();

//对单例进行某些初始化，同时又维护其私有变量的实例
var application = function() {
    //私有变量和函数
    var components = new Array();
    //初始化：aseComponent()函数只是用于展示例子，不用管内容
    components.push(new BaseComponent());

    //公共：其中的方法都是有权访问数组components的特权方法
    return {
        getComponentCount: function() { //返回已注册的组件数目
            return components.length;
        },
        registerComponent: function(component) { //用于注册新组件
            if(typeof component == "object") {
                components.push(component);
            }
        }
    };
}();
```
　　17、增强的模块模式：在返回对象之前加入对其增强的代码。这种增强的模块模式适合那些单例必须是某种类型的实例，同时还必须添加某些属性和（或）方法对其加以增强的情况。  
　　如果上面的例子中，application对象必须是BaseComponent的实例，那么修改代码：在这个重写后的应用程序(application)单例中，修改了命名变量app的创建过程，因为它必须是BaseComponent的实例。这个实例实际上是application对象的局部变量版。此后，又为app对象添加了能够访问私有变量的公有方法，最后一步返回app对象，结果仍然是将它赋值给全局变量application。  
```
var application = function() {
    //私有变量和函数
    var components = new Array();
    //初始化：aseComponent()函数只是用于展示例子，不用管内容
    components.push(new BaseComponent());

    //创建application的一个局部副本
    var app = new BaseComponent();

    //公共接口
    app.getComponentCount: function() { //返回已注册的组件数目
        return components.length;
    };
    app.registerComponent: function(component) { //用于注册新组件
        if(typeof component == "object") {
            components.push(component);
        }
    };
    return app;
}();
```
　　18、小结：使用函数表达式可以无须对函数命名，从而实现动态编程。  
　　19、当函数内部定义其他函数时，就创建了闭包。闭包有权访问包含函数内部的所有变量。  
　　在后台执行环境中，闭包的作用域链包含着它自己的作用域、包含函数的作用域和全局作用域。  
　　通常，函数的作用域及其所有变量都会在函数执行结束后被销毁。  
　　但是，当函数返回了一个闭包时，这个函数的作用域将会一直在内存中保存到闭包不存在为止。  
