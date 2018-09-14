# 第六章 面向对象的程序设计
　　0、变量以下划线_开头，用于表示只能通过对象方法访问的属性。
　　1、面向对象（Object-Oriented, OO）的语言有一个标志：有类的概念，且通过类可以创建任意多个具有相同属性和方法的对象。  
　　2、ECMAScript中有两种属性：数据属性和访问器属性。  
　　3、数据属性：包含一个数据值的位置，在这个位置可以读取和写入值。数据属性有4个描述其行为的特性。  
　　[[Configurable]]：表示能否通过delete删除属性从而重新定义属性，能否修改属性的特性，或者能否把属性修改为访问器属性。直接在对象上定义的属性的这个特性默认true。  
　　[[Enumerable]]：表示能否通过for-in循环返回属性。直接在对象上定义的属性的这个特性默认true。  
　　[[Writable]]：表示能否修改属性的值。直接在对象上定义的属性的这个特性默认true。    
　　[[Value]]：包含这个属性的数据值。读取属性值的时候，从这个位置读；写入属性值的时候，把新值保存在这个位置。这个特性的默认值为undefined。要修改属性默认的特性，必须使用Object.defineProperty()方法，接收三个参数：属性所在的对象、属性的名字、一个描述符对象。其中，描述符(descriptor)对象的属性必须是: configurable、enumerable、writable、value。设置其中的一个或多个值，可以修改对应的特性值。在调用该方法时，如果不指定前面三个属性，它们都默认是false。  
```
var obj1 = {
    name: "Epu" //为name属性指定的值为"Epu"，则前三个默认为true，而[[Vaule]]被设置为"Epu"
}
console.log(obj1.name); //Epu
delete obj1.name;
console.log(obj1.name); //undefined

var obj2 = {};
Object.defineProperty(obj2, "name", {
    configurable: false, //不能从对象中删除属性
    value: "Epu"
});
console.log(obj2.name); //Epu
delete obj2.name;
console.log(obj2.name); //Epu

//再次修改该属性：抛出错误
//可以多次调用该方法修改同一个属性
//但在把configurable特性设置为false后就会有限制了
Object.defineProperty(obj2, "name", {
    configurable: true,
    value: "Epu"
});
```
　　4、访问器属性：不包含数据值，包含一对儿getter和setter函数，但它们都不是必需的。读取访问器属性时，会调用getter函数，该函数负责返回有效的值；在写入访问器属性时，会调用setter函数并传入新值，该函数负责决定如何处理数据。访问器属性有4个特性，它们不能直接定义，必须使用Object.definedProperty()来定义。只指定getter意味着属性不能写，普通模式下尝试写入会被忽略，严格模式下会抛出错误；只指定setter情况相同。在不支持Object.defineProperty()方法的浏览器中不能修改[[Configurable]]和[[Enumerable]]。  
[[Configurable]]: 能否通过delete删除属性从而重新定义属性，能否修改属性的特性，或者能否把属性修改为数据属性。对于直接在对象上定义的属性，这个特性的默认值为true。  
[[Enumerable]]: 能否通过for-in循环返回属性。对于直接在对象上定义的属性，这个特性的默认值为true。  
[[Get]]: 在读取属性时调用的函数，默认值为undefined。  
[[Set]]: 在写入属性时调用的函数，默认值为undefined。  
```
var book = {
    _year: 2004,
    edition: 1
};

Object.defineProperty(book, "year", {
    get: function() {
        return this._year;
    },
    set: function(newValue) {
        if(newValue > 2004) {
            this._year = newValue;
            this.edition += newValue - 2004;
        }
    }
})

book.year = 2005;
console.log(book.edition); //2
console.log(book); //{ _year: 2005, edition: 2 } year是访问器属性，只能点出来，另外两个是数据属性
console.log(book.year); //2005
```
　　5、Object.defineProperties()：通过描述符一次定义多个属性。两个对象参数：第一个对象时要添加和修改其属性的对象，第二个对象的属性与第一个对象中国要添加或修改的属性一一对应。  
```
var book = {};
//定义两个数据属性和访问器属性，最终对象与上一节中相同，但这里的属性是在同一时间创建的
Object.defineProperties(book, {
    _year: {
        value: 2004
    },
    edition: {
        value: 1
    },
    year: {
        get: function() {
            return this._year;
        },
        set: function(newValue) {
            if(newValue > 2004) {
                this._year = newValue;
                this.edition += newValue - 2004;
            }
        }
    }
})

console.log(book.edition); //1
console.log(book); //{} 使用该方法，在不同浏览器里表现不同，最好是点出来
console.log(book.year); //2004
```
　　6、Object.getOwnProtyDescriptor()：获取给定属性的描述符。两个参数：属性所在的对象、要读取其描述符的属性名称。返回值是一个对象：如果是访问器属性，则对象属性有configurable、enumerable、get、set；如果是数据属性，则对象属性有configurable、enumerable、writable、value。在JavaScript中，可以针对包括DOM和BOM对象的任何对象使用该方法。  
```
//对于数据属性_year
var des = Object.getOwnPropertyDescriptor(book, "_year");
console.log(des.value); //2004 最初的值
console.log(des.configurable); //false 默认值
console.log(typeof des.get); //undefined 默认值
//对于访问器属性year
var des = Object.getOwnPropertyDescriptor(book, "year");
console.log(des.value); //undefined 默认值
console.log(des.enumerable); //false 默认值
console.log(typeof des.get); //function 指向getter函数的指针
```
　　7、工厂模式创建对象：软件工程领域一种广为人知的设计模式，它抽象了创建具体对象的过程。优化使用构造函数或对象字面量创建对象的缺点：使用同一个接口创建很多对象，产生大量的重复代码。  
```
function createObj(name, age) {
    var o = new Object();
    o.name = name;
    o.age = age;
    o.sayName = function() {
        console.log(this.name);
    };
    return o;
}

var obj1 = createObj("a", "1");
var obj2 = createObj("c", "1");
```
　　8、构造函数模式创建对象：。构造函数的函数名以大写字母开头，而非构造函数的函数名应以小写字母开头。  
```
//没有显示创建对象、将属性和方法赋给this对象、没有return语句
function CreateObj(name, age) {
    this.name = name;
    this.age = age;
    this.sayName = function() {
        console.log(this.name);
    };
}

var obj1 = new CreateObj("a", "1");
var obj2 = new CreateObj("c", "1");

console.log(obj1.constructor == CreateObj); //true 两个对象都有一个constructor(构造函数)属性，该属性指向CreateObj
console.log(obj1 instanceof CreateObj); //true CreateObj的实例
console.log(obj1 instanceof Object); //true Object的实例
```
　　9、构造函数与其他函数的唯一区别在于调用它们的方式不同。任何函数，只要通过new操作符来调用，就可以作为构造函数；不用new操作符就是普通函数。  
```
function CreateObj(name, age) {
    this.name = name;
    this.age = age;
    this.sayName = function() {
        console.log(this.name);
    };
}

//作为构造函数调用
var obj = new CreateObj("a", "1");
obj.sayName(); //a

//作为普通函数调用
CreateObj("b", "1");
sayName(); //b

//在另一个对象的作用域中调用
var o = new Object();
CreateObj.call(o, "c", "1");
o.sayName(); //c
```
　　10、构造函数的问题：每个方法都要在实例上重新创建一遍。上面实例化的obj1和obj2分别创建了一个sayName()的函数，它们虽然是同名的，但实际上并没有指向同一个Function实例，而是两个不同的Function实例。为了避免这种重复，并且this对象的存在使得根本不用再执行代码前就把函数绑定到对象上，可以将构造函数放到外部来解决该问题。  
　　但是，这种方法又带来了新的问题：在全局作用域中定义的函数sayName()实际上只能被某个对象调用，因而全局作用域有点儿名不副实；当构造函数中有个多个函数时，就需要像上面的sayName一样定义多个全局函数，那么它就不具备封装性了。  
```
console.log(obj1.sayName == obj2.sayName); //false 它们是不同的Function实例

function CreateObj(name, age) {
    this.name = name;
    this.age = age;
    this.sayName = sayName; //不执行函数时不能有括号
}

function sayName() {
    console.log(this.name);
};
```
　　11、原型模式：每个函数都有一个prototype(原型)属性，它是一个指针，指向一个对象，而这个对象时包含可以由特定类型的所有实例共享的属性和方法。使用原型对象将这些信息直接添加到其中，可以让所有对象实例共享它所包含的属性和方法，从而不必在构造函数中定义对象实例的信息。  
　　通过这种方法创建的所有属性和方法都是由实例共享的，因此obj1和obj2访问的是同一组属性和同一个sayName()函数。  
```
function CreateObj() {
}

CreateObj.prototype.name = "Ep";
CreateObj.prototype.age = "18";
CreateObj.prototype.sayName = function() {
    console.log(this.name);
}

var obj1 = new CreateObj();
var obj2 = new CreateObj();

console.log(obj1.sayName == obj2.sayName); //true
```
　　12、原型对象：只要创建了一个新函数，ECMAScript就会根据一组特定的规则为该函数创建一个prototype属性，这个属性指向函数的原型对象。在默认情况下，所有原型对象都会自动获得一个constructor(构造函数)属性，这个属性包含一个指向prototype属性所在函数的指针。通过这个构造函数，还可以继续为原型对象添加其他属性和方法。  
　　创建了自定义的构造函数后，其原型对象默认只会取得constructor属性；其他方法都是从Object继承而来。当调用构造函数创建一个新实例后，该实例内部将包含一个指针（内部属性），指向构造函数的原型对象。ECMA-262第五版中叫这个指针[[Prototype]]。  
　　在所有实现中都无法访问到[[Prototype]]，但可以通过isPrototypeOf()方法来确定。  
　　ECMAScript5增加了Object.getPrototypeOf()方法，返回[[Prototype]]的值。  
　　每当代码读取某个对象的某个属性时，都会执行一次搜索，目标是具有给定名字的属性。搜索首先从对象实例本身开始。如果在实例中找到了具有给定名字的属性，则具有该属性的值；如果没有找到，则继续搜索指针指向的原型对象，在原型对象中查找具有给定名字的属性。如果在原型对象中找到了这个属性，则返回该属性的值。  
```
console.log(CreateObj.prototype.isPrototypeOf(obj1)); //true obj1内部有一个指向CreateObj.prototype的指针，因此返回了true

console.log(Object.getPrototypeOf(obj1) == CreateObj.prototype); //true 确定方法返回的实际对象就是这个对象的原型
console.log(Object.getPrototypeOf(obj1).name); //Ep 获取原型对象中name属性的值
```
　　13、可以通过对象实例访问保存在原型中的值，但不能通过原型对象实例重写原型中的值。当为对象实例添加一个属性时，这个属性会阻止访问原型中的对应属性，但不会修改。使用delete操作符可以完全删除实例属性，从而能够重新访问原型中的属性。  
```
var obj1 = new CreateObj();
console.log(obj1.name); //Ep
console.log(obj1); //CreateObj {}

obj1.name = "Epu";
console.log(obj1.name); //Epu
console.log(Object.getPrototypeOf(obj1).name); //Ep
console.log(obj1); //CreateObj { name: 'Epu' }

delete obj1.name;
console.log(obj1.name); //Ep
console.log(obj1); //CreateObj {}
```
　　14、hasOwnProperty()：检测一个属性是存在于实例中，还是存在于原型中。从Object继承而来，只在给定属性存在于对象实例中时，才会返回true。要取得原型属性的描述符，必须在原型对象上调用前面提到的Object.getOwnPropertyDescriptor()方法。  
```
function CreateObj() {
}

CreateObj.prototype.name = "Ep";
CreateObj.prototype.age = "18";
CreateObj.prototype.sayName = function() {
    console.log(this.name);
}

var obj1 = new CreateObj();
console.log(obj1.hasOwnProperty("name")); //false 原型属性

obj1.name = "Epu";
console.log(obj1.name); //Epu
console.log(obj1.hasOwnProperty("name")); //true 实例属性

delete obj1.name;
console.log(obj1.name); //Ep
console.log(obj1.hasOwnProperty("name")); //false
```
　　15、in操作符：有两种方式使用in操作符：单独使用、在for-in循环中使用。  
　　16、原型与in操作符：在单独使用in操作符时，通常会在通过对象能够访问给定属性时返回true，无论该属性存在于实例中还是原型中。  
```
var obj1 = new CreateObj();
console.log("name" in obj1); //true

obj1.name = "Epu";
console.log("name" in obj1); //true
```
　　17、同时使用hasOwnProperty()方法和in操作符可以确定该属性是存在于对象中还是存在于原型中。前者返回false后者返回true则是原型中属性，两者返回true则是对象/实例中属性  
　　18、在for-in循环时，返回的是所有能够通过对象访问的、可枚举的(enumerated)属性，其中既包括存在于实例中的属性，也包括存在于原型中属性。即使屏蔽了原型中不可枚举属性（即将[[Enumerable]]标记为false的属性）的实例属性也会在for-in循环中返回，因为根据规定，所有开发人员定义的属性都是可枚举的——IE8及之前例外。  
　　19、Object.keys()方法：取得对象上所有可枚举的实例属性。一个参数参数：对象。返回一个包含所有可枚举属性的字符串数组。  
　　Object.getOwnPropertyNames()方法：得到所有实例属性，无论是否可枚举。  
```
console.log(Object.keys(CreateObj)); //[]
console.log(Object.keys(CreateObj.prototype)); //[ 'name', 'age', 'sayName' ]

console.log(Object.getOwnPropertyNames(CreateObj)); //[ 'length', 'name', 'arguments', 'caller', 'prototype' ]
console.log(Object.getOwnPropertyNames(CreateObj.prototype)); //[ 'constructor', 'name', 'age', 'sayName' ]

var obj1 = new CreateObj();
obj1.name = "Epu";
console.log(Object.keys(obj1)); //[ 'name' ]
console.log(Object.getOwnPropertyNames(obj1)); //[ 'name' ]
```
　　20、更简洁的原型语法：将CreateObj.prototype设置为等于一个以对象字面量形式创建的新对象。但此时constructor属性不再指向原来的CreateObj，因为此时本质上完全重写了默认的prototype对象，因此constructor属性也变成了新对象的constructor属性，它指向构造函数，而不是CreateObj函数，因此通过它也无法确定对象的类型。可像代码中那样设置它可以设置回适当的值。但这种方式会导致它的[[Enumerable]]特性被设置为true，然而由于默认情况下原生的constructor属性是不可枚举的，因此在兼容ECMAScript5的JavaScript引擎下，使用Object.defineProperty()方法重设。  
```
function CreateObj() {
}

CreateObj.prototype = {
    //constructor: CreateObj, //如果需要设置constructor属性值指向CreateObj函数的设置方法
    name: "Epu",
    age: 18,
    sayName: function() {
        console.log(this.name);
    }
};

var obj1 = new CreateObj();
console.log(obj1 instanceof Object); //true
console.log(obj1 instanceof CreateObj); //true
console.log(obj1.constructor == Object); //true 释放注释掉的constructor则为false
console.log(obj1.constructor == CreateObj); //false 释放注释掉的constructor则为true

//不要上面代码中的constructor，而这样写，但只适用于兼容ECMAScript5的JavaScript引擎
Object.defineProperty(CreateObj.prototype, "constructor", {
    enumerable: false,
    value: CreateObj
});
```
　　21、原型的动态性。  
```
function CreateObj() {
}

var obj1 = new CreateObj();

CreateObj.prototype = {
    name: "Epu",
    age: 18,
    sayName: function() {
        console.log(this.name);
    }
};

obj1.sayName(); //报错：obj1.sayName is not a function

var obj2 = new CreateObj();

CreateObj.prototype.sayAge = function() {
    console.log(this.age);
}

obj2.sayAge(); //18
```
　　22、实例中的指针仅指向原型，而不指向构造函数。  
　　23、原生对象的原型：所有原生的引用类型都是采用原型模式创建的。所有原生引用类型(Object、Array、String等)都在其构造函数的原型上定义了方法。因此，通过原生对象的原型，不仅可以取得所有默认方法的引用，还可以定义新方法。可以像修改自定义对象的原型一样修改原生对象的原型，因此可以随时添加方法。  
　　但不推荐在产品化的程序中修改原生对象的原型。如果因某个实现中缺少某个方法，就在原生对象的原型中添加这个方法，那么当在另一个支持该方法的实现中可能会导致命名冲突。另外还可能会意外地重写原生方法。  
　　24、原型对象问题：不能为构造函数传递参数，因而所有实例在默认情况下都将取得相同属性值；最大问题是由其共享的本性所导致的。  
　　原型中所有属性是被很多实例共享的，这种共享对于函数非常合适；对于包含属性值的属性一般，毕竟通过在实例上添加一个同名属性可以隐藏原型中的对应属性；但对于包含引用类型值的属性来说，存在很大问题。  
```
function CreateObj() {
}

CreateObj.prototype = {
    name: "Epu",
    age: 18,
    friends: ["a", "b"],
    sayName: function() {
        console.log(this.name);
    }
};

var obj1 = new CreateObj();
var obj2 = new CreateObj();

obj1.friends.push("c");
console.log(obj1.friends); //[ 'a', 'b', 'c' ]
console.log(obj2.friends); //[ 'a', 'b', 'c' ]
console.log(obj1.friends == obj2.friends); //true
```
　　25、构造函数模式和原型模式的组合使用：创建自定义类型的最常见方式。构造函数模式用于定义实例属性，原型模式用于定义方法和共享属性。因此，每个实例有自己的一份实例属性的副本，但同时又共享着对方法的引用，最大限度地节省了内存。并且这种混成模式还支持向构造函数传递参数。  
```
function CreateObj(name, age) {
    this.name = name;
    this.age = age;
    this.friends = ["a", "b"];
}

CreateObj.prototype = {
    constructor: CreateObj,
    sayName: function() {
        console.log(this.name);
    }
};

var obj1 = new CreateObj("a", 1);
var obj2 = new CreateObj("b", 2);

obj1.friends.push("c");
console.log(obj1.friends); //[ 'a', 'b', 'c' ]
console.log(obj2.friends); //[ 'a', 'b' ]
console.log(obj1.friends == obj2.friends); //false
console.log(obj1.sayName == obj2.sayName); //true
```
　　26、动态原型模式：把所有信息封装在构造函数中，而通过在构造函数中初始化原型（仅在必要的情况下），又保持了同时使用构造函数和原型的优点。也就是，可以通过检查某个应该存在的方法是否有效，来决定是否需要初始化原型。  
```
function CreateObj(name, age) {
    this.name = name;
    this.age = age;

    if (typeof this.sayName != "function") {
        CreateObj.prototype.sayName = function() {
            console.log(this.name);
        }
    };

}
var obj1 = new CreateObj("a", 1);
obj1.sayName(); //a
```
　　27、构造函数在不返回值的情况下，默认返回新对象的实例；而添加return后可以重写调用构造函数时返回的值。  
　　28、寄生(parasitic)构造函数模式：创建对象，以相应的属性和方法初始化该对象，然后返回这个对象。在前面的几种模式都不适用的情况下可以使用的方法。基本思想：创建一个函数，其作用仅仅是封装创建对象的代码，然后再返回新创建的对象；但从表面上看，这个函数很像是典型的构造函数。  
　　该模式返回的对象与构造函数或者构造函数的原型属性之间没有关系。即构造函数返回的对象与在构造函数外部创建的对象没有什么不同。因此不能使用instanceof操作符来确定对象类型。因此一般情况下不建议使用这种模式。  
```
function CreateObj(name, age) {
    var obj = new Object();
    obj.name = name;
    obj.age = age;
    obj.sayName = function() {
        console.log(this.name);
    }
    return obj;
}
var obj1 = new CreateObj("a", 1);
obj1.sayName(); //a
```
　　29、在特殊情况下用寄生(parasitic)构造函数模式为对象创建构造函数。  
```
//创建一个具有额外方法的特殊数组，并且不能直接修改Array构造函数
function SpecialArray() {
    //创建数组
    var values = new Array();
    //添加值: 用构造函数接收到的所有参数初始化数组值
    values.push.apply(values, arguments);
    //添加方法
    values.toPipedString = function() {
        return this.join(" | ");
    };
    //返回数组
    return values;
}
var colors = new SpecialArray("red", "blue", "green");
console.log(colors.toPipedString()); //red | blue | green
```
　　30、稳妥构造函数模式：稳妥对象(durable objects)指没有公共属性，其方法不引用this的对象。稳妥对象适合在一些安全的环境中（这些环境中会禁止使用this和new），或者在防止数据被其他应用程序改动时使用。
　　稳妥构造函数遵循与寄生构造函数类似的模式，有两点不同：新创建对象的实例方法不引用this、不适用new操作符调用构造函数。  
　　在下面的例子中，变量obj1中保存的是一个稳妥对象，而除了调用sayName()方法外没有别的方法可以访问其数据成员。即使有其他代码会给这个对象添加方法或数据成员，但也不可能有别的方法访问传入到构造函数中的原始数据。  
```
function CreateObj(name, age) {
    var obj = new Object();
    //这些是相同的
    obj.name = name;
    obj.age = age;
    obj.sayName = function() {
        console.log(name); //没有this
    }
    return obj;
}
var obj1 = CreateObj("a", 1); //没有new
obj1.sayName(); //a
```
　　30、构造函数、原型、实例的关系：每个构造函数都有一个原型对象，原型对象都包含一个指向构造函数的指针，实例都包含一个指向原型对象的内部指针。  
　　31、继承：许多OO语言支持的继承方式：接口继承和实现继承。前者只继承方法签名，后者继承实际的方法。由于函数没有签名，因此ECMAScript只支持实现继承，并且主要依靠原型链实现。  
　　32 、原型链：实现继承的主要方法。基本思想：利用原型让一个引用类型继承另一个引用类型的属性和方法。  
　　原型链的基本概念：如果让原型对象等于另一个类型的实例，则此时的原型对象将包含一个指向另一个原型的指针，相应地，另一个原型中也包含着一个指向另一个构造函数的指针。加入另一个原型又是另一个类型的实例，那么上诉关系依然成立，如此层层递进，就构成了实例与原型的链条。  
　　子类型有时候需要重写超类型中的某个方法，或者需要添加超类型中不存在的某个方法，但不管怎样，给原型添加方法的代码一定要放在替换原型的语句之后。  
　　通过原型链实现继承时，不能使用对象字面量创建原型方法，因为这样做会重写原型链，则这样的原型包含的是一个Object的实例，而非SuperType的实例，则继承语句无效。  
```
function SuperType() {
    this.property = true;
}
SuperType.prototype.getSuperValue = function() {
    return this.property;
}

function SubType() {
    this.subproperty =false;
}

//继承了SuperType：重写原型对象，代之以一个新类型的实例
SubType.prototype = new SuperType();

SubType.prototype.getSubValue = function() {
    return this.subproperty;
}

var instance = new SubType();
console.log(instance.getSubValue()); //false
console.log(instance.getSuperValue()); //true

console.log(instance instanceof Object); //true
console.log(instance instanceof SuperType); //true
console.log(instance instanceof SubType); //true

//重写超类中的方法
SubType.prototype.getSuperValue = function() {
    return false;
}

console.log(instance.getSubValue()); //false
console.log(instance.getSuperValue()); //false

console.log(instance instanceof Object); //true
console.log(instance instanceof SuperType); //true
console.log(instance instanceof SubType); //true

//使用字面量添加新方法，重写原型链，SubType.prototype = new SuperType()无效
SubType.prototype = {
    getSubValue: function() {
        return this.subproperty;
    },
    someOtherMethod: function() {
        return false;
    }
}

console.log(instance.getSubValue()); //false
console.log(instance.getSuperValue()); //false

var instance1 = new SubType();
console.log(instance1.getSubValue()); //false
console.log(instance1.getSuperValue()); //报错
```
　　33、原型链的问题：最主要的问题来自包含引用类型值的原型。在通过原型来实现继承时，原型实际上会变成另一个类型的实例。从而原先的实例属性也顺理成章地变成了现在的原型属性了，而前面提到过包含引用类型值的原型属性会被所有实例共享。  
　　第二个问题：在创建子类型的实例时，不能向超类型的构造函数中传递参数。实际上，应该说是没有办法在不影响所有对象实例的情况下，给超类型的构造函数传递参数。由于这两个问题的存在，实践中很少会单独使用原型链。  
```
function SuperType() {
    this.colors = ["red", "blue", "green"];
}
function SubType() {
}

//继承了SuperType：重写原型对象，代之以一个新类型的实例
SubType.prototype = new SuperType();

var instance1 = new SubType();
instance1.colors.push("black");
console.log(instance1.colors); //[ 'red', 'blue', 'green', 'black' ]

var instance2 = new SubType();
console.log(instance2.colors); //[ 'red', 'blue', 'green', 'black' ]
```
　　34、借用构造函数：在子类型构造函数的内部调用超类型构造函数。  
　　下面例子中使用call()方法（或者apply()方法也可以），实际上是在（未来将要）新创建的SubType实例的环境下调用SuperType构造函数。这样，就会在新SubType对象上执行SuperType()函数中定义的所有对象初始化代码。结果，SubType的每个实例就会具有自己的colors属性的副本了。  
　　优点：在子类型构造函数中向超类型构造函数传递参数。为了确保SuperType构造函数不会重写子类型的属性，可以在调用超类型构造函数后，再添加应该在子类型中定义的属性。  
　　问题：如果只是借用构造函数，则方法都在构造函数中定义，因此函数无法复用。并且在超类型的原型中定义的方法对子类型是不可见的，因此所有类型都只能使用构造函数魔术。因此这种方法也很少单独使用。  
```
function SuperType() {
    this.colors = ["red", "blue", "green"];
}
function SubType() {
    //继承了SuperType
    SuperType.call(this);
    //子类型中定义的属性
    this.age = 18;
}

var instance1 = new SubType();
instance1.colors.push("black");
console.log(instance1.colors); //[ 'red', 'blue', 'green', 'black' ]
console.log(instance1.age); //18

var instance2 = new SubType();
console.log(instance2.colors); //[ 'red', 'blue', 'green' ]
```
　　35、组合继承(combination inheritance)：也叫伪经典继承。将原型链和借用构造函数的技术组合到一块，从而发挥二者之长的一种继承模式。思路：使用原型链实现对原型属性和方法的继承，而通过借用构造函数来实现对实例属性的继承。这样，既通过在原型上定义方法实现了函数复用，又能够保证每个实例都有它自己的属性。  
　　组合继承避免了原型链和借用构造函数的缺陷，融合了它们的优点，称为JavaScript中最常用的继承模式。而且，instanceof和isPrototypeOf()也能够用于识别基于组合继承创建的对象。  
```
function SuperType(name) {
    this.name = name;
    this.colors = ["red", "blue", "green"];
}

SuperType.prototype.sayName = function() {
    console.log(this.name);
}

function SubType(name, age) {
    //继承了属性
    SuperType.call(this, name);
    this.age = age;
}

//继承方法
SubType.prototype = new SuperType();
SubType.prototype.constructor = SubType;
SubType.prototype.sayAge = function() {
    console.log(this.age);
};

var instance1 = new SubType("Ep", 18);
instance1.colors.push("black");
console.log(instance1.colors); //[ 'red', 'blue', 'green', 'black' ]
instance1.sayName(); //Ep
instance1.sayAge(); //18

var instance2 = new SubType("Epu", 19);
console.log(instance2.colors); //[ 'red', 'blue', 'green' ]
instance2.sayName(); //Epu
instance2.sayAge(); //19
```
　　36、原型式继承：ECMAScript5中新增了Object.create()方法规范化了原型式继承。两个参数：用作新对象原型的对象、(可选的)新对象定义额外属性的对象。在没有必要创建构造函数，而只想让一个对象与另一个对象保持类似的情况下，原型式继承时完全可以胜任的。但是包含引用类型值的属性始终都会共享相应的值，就像使用原型模式一样。  
```
//原理
function object(o) {
    function F() {}
    F.prototype = o;
    return new F();
}

//使用Object.create()则是基于上面的原理实现的
var person = {
    name: "Epu",
    friends: ["a", "b"]
};

var person1 = Object.create(person);
person1.name = "per1";
person1.friends.push("c");

var person2 = Object.create(person);
person2.name = "per2";
person2.friends.push("d");

console.log(person.friends) //[ 'a', 'b', 'c', 'd' ]

console.log(person1.friends) //[ 'a', 'b', 'c', 'd' ]
console.log(person1.name) //per1
console.log(person2.friends) //[ 'a', 'b', 'c', 'd' ]
console.log(person2.name) //per2

var person3 = Object.create(person, {
    name: {
        value: "per3"
    }
});
console.log(person3.friends) //[ 'a', 'b', 'c', 'd' ]
console.log(person3.name) //per3
```
　　37、寄生式(parasitic)继承：创建一个仅用于封装继承过程的函数，该函数在内部以某种方式来增强对象，最后再像真的是它做了所有工作一样返回对象。在主要考虑对象而不是自定义类型和构造函数的情况下，寄生式继承也是一种有用的模式。下面例子中使用的object()函数不是必需的，任何能够返回新对象的函数都适用于此模式。  
```
function object(o) {
    function F() {}
    F.prototype = o;
    return new F();
}
function createPerson(original) {
    var clone = object(original); //通过调用函数创建一个新对象
    clone.sayHi = function() { //以某种方式来增强这个对象
        console.log("hi");
    };
    return clone; //返回这个对象
}

var person = {
    name: "Epu",
    friends: ["a", "b"]
};

var person1 = createPerson(person);
person1.sayHi(); //hi
```
　　38、组合继承缺点：无论什么情况下，都会调用两次超类型构造函数：一次是创建子类型原型的时候、另一次是在子类型构造函数内部。子类型最终会包含超类型对象的全部实例属性，但我们不得不在调用子类型构造函数时重写。  
```
function SuperType(name) {
    this.name = name;
    this.colors = ["red", "blue", "green"];
}

SuperType.prototype.sayName = function() {
    console.log(this.name);
}

function SubType(name, age) {
    //继承了SuperType
    //第二次调用SuperType()，在新对象上创建实例属性name/colors
    //屏蔽了第一次调用时原型得到的两个同名属性
    SuperType.call(this, name);

    this.age = age;
}

//第一次调用SuperType()，SubType.prototype得到两个属性：name/colors
//它们都是SuperType的实例属性，但现在位于SubType的原型中
SubType.prototype = new SubType();

SubType.prototype.constructor = SubType;
SubType.prototype.sayAge = function() {
    console.log(this.age);
}
```
　　39、寄生组合式继承：通过借用构造函数来继承属性，通过原型链的混成形式来继承方法。基本思路：不必为了指定子类型的原型而调用超类型的构造函数，我们需要的只是超类型原型的副本。本质上，就是使用寄生式继承来继承超类型的原型，然后再将结果指定给子类型的原型。开发人员普遍认为寄生组合式继承时引用类型最理想的继承范式。  
```
function object(o) {
    function F() {}
    F.prototype = o;
    return new F();
}

//该函数为寄生组合式继承的基本模式
function inheritPrototype(subType, superType) {
    //创建对象：创建超类型原型的副本
    var prototype = object(superType.prototype);
    //增强对象：为创建的副本添加constructor属性，从而弥补因重写原型而失去的默认的该属性
    prototype.constructor = subType;
    //指定对象：将新创建的对象(即副本)赋值给子类型的原型
    subType.prototype = prototype;
}

function SuperType(name) {
    this.name = name;
    this.colors = ["red", "blue", "green"];
}

SuperType.prototype.sayName = function() {
    console.log(this.name);
}

function SubType(name, age) {
    SuperType.call(this, name);
    this.age = age;
}

inheritPrototype(SubType, SuperType);

SubType.prototype.sayAge = function() {
    console.log(this.age);
}

var instance1 = new SubType("a", 18);
console.log(instance1.name); //a
console.log(instance1.age); //18
instance1.sayName(); //a
instance1.sayAge(); //18
instance1.colors.push("black");
console.log(instance1.colors); //[ 'red', 'blue', 'green', 'black' ]

var instance2 = new SubType("b", 19);
console.log(instance2.name); //b
console.log(instance2.age); //19
instance2.sayName(); //b
instance2.sayAge(); //19
console.log(instance2.colors); //[ 'red', 'blue', 'green' ]
```
　　40、小结：ECMAScript支持面向对象（OO）编程，但不使用类或接口。  
　　41、对象可以在代码执行过程中创建和增强，因此具有动态性而非严格定义的实体。  
　　42、在没有类的情况下，可以采用下列模式创建对象：  
　　工厂模式：使用简单函数创建对象，为对象添加属性和方法，然后返回对象。这个模式后来被构造函数模式所取代。  
　　构造函数模式：可以创建自定义引用类型，可以像创建内置对象实例一样使用new操作符。但它的每个成员无法得到复用，包括函数。由于函数可以不局限于任何对象（即与对象具有松散耦合的特点），因此没有理由不在多个对象间共享函数。  
　　原型模式：使用构造函数的prototype属性来指定那些应该共享的属性和方法。  
　　组合使用构造函数模式和原型模式时，使用构造函数定义实例属性，使用原型定义共享的属性和方法。  
　　43、JavaScript主要通过原型链实现继承。原型链的构建时通过将一个类型的实例赋值给另一个构造函数的原型实现的。这样，子类型就能够访问超类型的所有属性和方法，这一点与基于类的继承很相似。  
　　原型链的问题是对象实例共享所有继承的属性和方法，因此不适宜单独使用。解决这个问题的技术是借用构造函数，即在子类型构造函数的内部调用超类型构造函数。这样就可以做到每个实例都具有自己的属性，同时还能保证只使用构造函数模式来定义类型。  
　　使用最多的继承模式是组合继承，这种模式使用原型链继承共享的属性和方法，而通过借用构造函数继承实例属性。  
　　此外，还存在下列可供选择的继承模式：  
　　原型式继承：可以在不必预先定义构造函数的情况下实现继承，其本质是执行对给定对象的浅复制。而复制得到的副本还可以得到进一步改造。  
　　寄生式继承：与原型式继承非常相似，也是基于某个对象或某些信息创建一个对象，然后增强对象，最后返回对象。为了解决组合继承模式由于多次调用超类型构造函数而导致的低效率问题，可以将这个模式与组合模式一起使用。  
　　寄生组合式继承：集寄生式继承和组合继承的优点于一身，是实现基于类型继承的最有效方式。  
