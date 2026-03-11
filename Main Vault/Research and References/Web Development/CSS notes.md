### Example Formatting
```
h1 {
	font-size: 12px;
	color: rgb(255, 50, 150);
}
```


### Editable CSS Properties
background-color: COLOR;
color: COLOR;
font-family: FONT;
font-size: NUMpt;

padding: NUMpx;

margin-left: NUMpx;
margin-right: NUMpx;
margin-top: NUMpx;
margin-bottom: NUMpx;


### Tips
- Set a border for tables
- width: fit-content;

.calculator-container {
    background-color: #ffffff;
    padding: 40px;
    border-radius: 12px;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
    width: 100%;
    max-width: 400px;
    text-align: center;
}

input[type="number"] {
    width: 100%;
    padding: 12px;
    border: 1px solid #ddd;
    border-radius: 8px;
    font-size: 1rem;
    box-sizing: border-box;
}


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
