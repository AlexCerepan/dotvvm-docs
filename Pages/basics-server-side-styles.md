## Server-side Styles

**DotVVM** supports Server-side styles which enable changing the style or attributes of specified controls across the whole application.

To use them you can register a `Style` in the `StyleRepository` which is a property of `DotvvmConfiguration`. You have to specify the type of the control which has to derive from `DotvvmBindableObject` or use a parameter with tag name of HTML element:

```CSHARP
// Modify all controls derived from ButtonBase
config.Styles.Register<ButtonBase>();

// Modify all HTML elements with tag name input
config.Styles.Register("input");
```

>If you register the style by specifying the tag name **DotVVM** controls will not be modified

It is also possible to set a condition under which the styles will be applied. To do that use `Register(Func<StyleMatchContext, bool>)`. If this function returns `true` the styles are going to be applied, otherwise nothing happens.

```CSHARP
// This will hide every control derived from ButtonBase that does not have the Click property
config.Styles.Register<ButtonBase>(b => !b.HasProperty(ButtonBase.ClickProperty), allowDerived: true)
    .SetAttribute("style", "display:none;");
```

The styles are applied during the compilation of a view. The `StyleMatchContext` has methods for checking data contexts, ancestors and other properties of the object. You can even check whether the view the object is included in is in a specific directory:

```CSHARP
config.Styles.Register<GridView>(c => c.HasAncestor<Repeater>() && c.HasDataContext<AccountInfo>()
		&& c.HasViewInDirectory("~/Views/Logs/"))
	.SetDotvvmProperty(GridView.VisibleProperty, false);
```

The `Register` method returns an instance of `StyleBuilder` that lets you modify the control. You can set default values of attributes and properties or override them completely. These method calls can also be chained.

```CSHARP
// This will change the class on all buttons that do not have any
config.Styles.Register<Button>()
  .SetAttribute("class", "ButtonClass");

// This will override the class of all textboxes and disable them.
config.Styles.Register<TextBox>()
  .SetAttribute("class", "TextBoxClass", append: true)
  .SetAttribute("disabled", "disabled");

// This will override the text of all buttons
config.Styles.Register<Button>()
  .SetDotvvmProperty(Button.TextProperty, "Button");
```

>The default value for `append` in the `SetAttribute` method is false while in `SetDotvvmProperty` it is `true`.
