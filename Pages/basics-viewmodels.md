## ViewModels

In **DotVVM**, the **viewmodel** can be any JSON-serializable class. The viewmodel does two important things:

+ It represents the state of the page (values in all form fields, options for ComboBoxes etc.).

+ It defines commands which can be invoked by the user (e.g. button clicks). 

```CSHARP
public class CalculatorViewModel 
{
    // The state of the page is represented by public properties.
    // If you serialize the viewmodel, you should have all the information to be able to restore the page in the exactly same state later.

    public int Number1 { get; set; }

    public int Number2 { get; set; }

    public int Result { get; set; }


    // The commands that can be invoked from the page are public methods.
    // They can modify the state of the viewmodel.

    public void Calculate() 
    {
        Result = Number1 + Number2;
    }
}
```

### ViewModel Limitations

The state part of the viewmodel is done using public properties. Please note that the **viewmodel must be JSON-serializable**. 

Therefore, a "DotVVM-friendly" viewmodel can contain properties of these types:

* `string`, `Guid`, `bool`, `int` and other numeric types and `DateTime`, including nullable ones (e.g. `decimal?`)

* enum

* another DotVVM-friendly object

* collections (array, `List<T>`) of DotVVM-friendly objects, enums or primitive types

> Please note that the `TimeSpan` and `DateTimeOffset` are not supported in the current version. 

### Recommendations for ViewModels

+ The properties in viewmodel and all child objects should have plain `{ get; set; }`. There should be no logic in getters, setters or the constructor of the class. The getters and setters are called by the serializatin mechanism and you never know the order in thich setters are invoked.

+ The viewmodel commands are part of the presentation layer. They shouldn't communicate with the database, send e-mails etc. 
In general, the viewmodel methods should only gather data from the viewmodel, call some method from the business layer to do  the real job and after it's finished, update the viewmodel with the results. 

> Please don't use Entity Framework `DbContext` directly in the viewmodel. These things should be in lower layer than in the presentation one. Look at the [samples](/docs/samples) to see how to architect the application in the layers.

> We also don't recommend exposing Entity Framework entities as viewmodel properties. Remember that the viewmodel is serialized, so the user can see all the columns including various IDs which may be private. 

> Also, you may end with errors because of the lazy loading, which might "expand" the entities and cause big data transfers, or fail on cyclic references which are not supported in JSON.  

> If you are using Entity Framework, create [Data Transfer Objects](https://en.wikipedia.org/wiki/Data_transfer_object) and use them in your viewmodel instead. You can use libraries like [AutoMapper](http://automapper.org/) to make the mapping between entities and DTOs really easy.


### DotvvmViewModelBase

We recommend to inherit all viewmodels from `DotvvmViewModelBase`. It is not required - any class can be the viewmodel. 

But the `DotvvmViewModelBase` class gives you several useful mechanisms that you may need (e.g. the `Context` property). If you cannot use it, consider using the `IDotvvmViewModel` interface to be able to get the `Context` property and the viewmodel events.

If the viewmodel derives from the `DotvvmViewModelBase`, you can override the `Init`, `Load` and `PreRender` methods. 

In the following diagram, you can see the lifecycle of the HTTP request. The left side shows what's going on when the client access the page first time (the HTTP GET request). The right side shows what happens during the postback (e.g. when the user clicks a button to call a method in the viewmodel).

<p><img src="{imageDir}basics-viewmodels-img1.png" alt="DotVVM Page Lifecycle" /></p>

## Binding Directions

When using the [command bindings](/docs/tutorials/basics-command-binding/{branch}), you may need to customize which properties are transferred 
from the server to client or from client to the server. Typically, there is no need to transfer the whole viewmodel in both directions. 

In DotVVM, you can configure what data is transferred using the `[Bind(direction)]` attribute. 

```CSHARP
[Bind(Direction.ServerToClient)]
public string SingleDirectionProperty { get; set; }
```

The direction is an enumeration with the following options - `Both`, `ServerToClient`, `ClientToServer` and `None`.

* **Both** is the default value - the property is transferred in both ways.

* **ServerToClient** - the changes of the property on the client side are not transferred to the server.

* **ClientToServer** - the server only reads the value of the property set by the client.

* **None** - the property is not serialized in any way.
