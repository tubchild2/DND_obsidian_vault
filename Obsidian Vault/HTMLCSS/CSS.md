- CSS rules specify styling properties for [[HTML]] elements (like p, h1, h2, h3)
- They go in a special <'style> tag and look like this
	- h1 { 
	  font-size: 12px; 
	  color: rgb(255, 50, 150); 
	  }
- Common CSS properties
	- background-color: INSERT COLOR;
	- color: INSERT COLOR;
		- rgb(255, 0, 0) yields red
		- rgb(0, 255, 0) yields green
		- rgb(0, 0, 255) yields blue
	- font-family: INSERT FONT;
	- font-size: -pt;
	- padding: -px;
	- margin-left: -px;
	- margin-top: -px;
	- margin-right: -px;
	- margin-bottom: -px;
- HOW TO MAKE TABLES NOT LOOK BAD
	- Within the style section, style the table, th, and td tags like so:
		 <'style>
		  table, th, td {
			  border: 2px solid gray;
			  }
		 <'/style>
![[Pasted image 20251014170853.png]]

![[Pasted image 20251014175739.png]]


## Element Class and ID selectors
1. The element selector matches elements with the specified element names.  
    Ex: `p { color: blue; }` selects all `<p>` elements.
2. The class selector, specified with a period character followed by the class name, matches elements that have the specified class name.  
    Ex: `.notice { color: blue; }` selects all elements with a `class="notice"` attribute.  
    Ex: `h1.notice { color: blue; }` selects only `<h1>` elements with a `class="notice"` attribute.
	- You can put multiple classes together with `<p class = "class1 class2>` and that'll have two classes. 
3. The ID selector, specified with a hash character followed by the ID name, matches the element that has the specified ID.  
    Ex: `#byLine { color: blue; }` selects the element with the `id="byLine"` attribute.
![[Pasted image 20251014181626.png]]
- If you're doing something like strong {} in CSS, you can make it even more specific with something like p strong {} which will only affect the bold text of paragraph elements. This is called a descendant selector. It's more specific.
- There are more selectors based on user input
	- :disabled - Element is disabled.
	- :hover - Mouse is hovering over the element.
	- :empty - Element has no child elements.
	- :lang(language) - Element contains text in a specified language.
	- :nth-child(n) - Element is the parent element's nth child.
		- tr:nth-child(even) {  background-color:lavender; }
		- th:hover { color:orange; }
![[Pasted image 20251014191908.png | 1000]]
![[Pasted image 20251014192237.png|1000]]
p{
	display:none;
}

## VARIABLES FINALLY

<style>
:root {
	--main-color: red;
	--main-bg-color: yellow;
}

p {
	color: var(--main-color);
	background-color: var(--main-bg-color);
}
</style>

<p>The sun rises and sets.</p>

- The CSS :root selector gives the variable global scope
- CSS variables must have a double dash prefix
- To use a variable, refer to it with var(--name)
- 



## STUFF I CANT TAKE GOOD NOTES ON
- Text decorations can make it under, through, and overlined
- Text align to align to the right left center or justify to the element
![[Pasted image 20251015211752.png]]

- There are CSS Properties for padding, border, and margin and you can edit their px
![[Pasted image 20251015211845.png]]

![[Pasted image 20251015212003.png | 1000]]![[Pasted image 20251015212429.png | 1000]]
