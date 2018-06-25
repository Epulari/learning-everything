# 第二章 在HTML中使用JavaScript
　　1、&lt;script&gt;&lt;/script&gt;的属性：  
　　　　*async*：解析DOM的同时下载脚本，然后立即执行脚本。动态脚本默认为真。在HTML中直接写async，而在XHTML中要写为async="async"。  
　　　　*charset*：通过src属性指定的代码的字符集  
　　　　*defer*：解析DOM的同时下载脚本，DOM解析完成后执行脚本  
　　　　*src*：要引入的外部代码文件  
　　　　*type*：编写代码使用的脚本语言的内容内行（即MIME类型）。  
　　其中，type的值text/javascript和text/ecmascript已经不推荐使用，但前者一直在使用。服务器传送的其实是application/x-javascript，但html可能不会解析它。非IE可以用application/javascript和application/ecmascript。考虑到约定和兼容，目前type默认属性值依旧为text/javascript，因此可以不指定。  
　　2、async/defer:bool，前者指示浏览器是否在允许的情况下异步执行该脚本；后者被设定用来通知浏览器该脚本将在文档完成解析后，触发DOMContentLoaded事件前执行。都对内联脚本无作用（即没有src属性的脚步）。  
　　3、一般理解，XHTML是更严格的HTML，编写更加规范。  
　　4、在现实当中，延迟脚本defer并不一定会按照顺序执行，也不一定会在DOMContentLoaded事件触发前执行，因此最好只包含一个延迟脚本。  
　　5、HTML5中明确规定，不支持嵌入脚本的defer属性，它只适用于外部脚本。但IE4-IE7支持嵌入脚本的defer属性。  
　　6、HTML5中明确规定，不支持嵌入脚本的async属性，它只适用于外部脚本。它不保证脚本按照指定的先后顺序执行，但一定会在页面的load事件前执行，但DOMContentLoaded事件触发的前后都可能。  
　　7、ECMA-262规定语言组成部分为：语法、类型、语句、关键字、保留字、操作符、对象。ECMAScript是对实现该标准规定的各个方面内容的语言的描述。Javascript实现了ECMAScript，Adobe ActionScript也实现了ECMAScript。第三版标志着ECMAScript成为了一门真正的编程语言。  
　　8、IE对ECMAScript兼容性：IE5第一版，IE5.5-IE7第三版，IE8第五版不完全兼容的实现，IE9+第五版。  
IE对DOM的支持：IE5一级最小限度，IE5.5-IE8一级最小限度几乎全部，IE9+一级二级三级。  
　　9、文档对象模型（Document Object Model, DOM）是针对XML但经过扩展用于HTML的应用程序编程接口（Application Programming Interface, API）。也即提供访问和操作网页内容的方法和接口。DOM把整个页面映射为一个多层节点结构。  
　　10、W3C（World Wide Web Consortium, 万维网联盟）：制定Web通信标准。  
　　11、使用浏览器对象模型（Browser Object Model, BOM）可以控制浏览器显示的页面以外的部分。也即是提供与浏览器交互的方法和接口。  
　　12、XHTML：Extensible HyperText Markup Language，可扩展超文本标记语言，是将HTML作为XML的应用而重新定义的一个标准。  
　　13、避免在XHTML中出现JavaScript语法错误的方法有：  
　　　　1）用相应的HTML实体，如用&lt;代替小于号<；  
　　　　2）用Cdata片段来包含JavaScript代码。在XHTML(XML)中，CData片段是文档中的特殊区域，该区域可以包含不需要解析的任意格式的文本内容。如下：  
```
<script type="text/javascript">
    &lt;![CDATA[
        //javascript code
    ]]&gt;
</script>
```
　　14、用外部文件包含JavaScript代码：可维护、可缓存、适应未来（HTML和XHTML等的变化）。  
　　15、不支持JavaScript时页面显示：&lt;noscript&gt;元素。当浏览器不支持脚本或浏览器支持脚本但脚本被禁用时会显示该元素中的内容。

**思考：**  
　　1、async执行时间、执行顺序不确定，因此最好只用于与其他脚本无关的脚本。并不是所有浏览器都支持defer。  
　　2、script使用src属性指向外部域时存在安全隐患。  
　　3、由于浏览器会先解析完不使用defer属性的&lt;script&gt;元素中的代码，然后再解析后面的内容，所以一般应该把&lt;script&gt;元素放在页面最后，即主要内容后面，&lt;/body&gt;标签前面。  



