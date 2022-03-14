# Exception filters

If you want to handle exceptions in a generic way using a [filter](overview), there is a class called `ExceptionFilterAttribute`. It derives from the `ActionFilterAttribute`, and provides the `OnCommandExceptionAsync` method, which is a common place where you can log or handle any exceptions. 

The `OnCommandExceptionAsync` is called whenever an error occurs in a method triggered by a [command](~/pages/concepts/respond-to-user-actions/commands) or a [static command](~/pages/concepts/respond-to-user-actions/static-commands).

The `ActionFilterAttribute` class then defines the `OnPageExceptionAsync` and `OnPresenterExceptionAsync` methods. These methods are called when any other exception occurs when the page or presenter is being processed. In most cases, it catches the exceptions in the `Init`, `Load` and `PreRender` in the viewmodel, and the exceptions that occur during the rendering or serialization phases. 

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Runtime.Filters;

namespace DotvvmDemo
{
    public class ErrorLoggingActionFilter : ExceptionFilterAttribute
    {
        protected override Task OnCommandExceptionAsync(IDotvvmRequestContext context, ActionInfo actionInfo, Exception exception)
        {
            // Log exceptions from commands in the viewmodel
            LogService.LogException(exception.ToString());

            return base.OnCommandExceptionAsync(context, actionInfo, exception);
        }
        
        protected override Task OnPageExceptionAsync(IDotvvmRequestContext context, Exception exception)
        {
            // Log other exceptions that occur during the page execution
            LogService.LogException(exception.ToString());

            return base.OnPageExceptionAsync(context, exception);
        } 

        protected override Task OnPresenterExceptionAsync(IDotvvmRequestContext context, Exception exception)
        {
            // Log other exceptions that occur during the page or custom presenter execution
            LogService.LogException(exception.ToString());

            return base.OnPresenterExceptionAsync(context, exception);
        }               
    }
}
```

## Handle exceptions from all commands

In many apps, the commands sometimes end with an exception. However, you don't always want to show the error page to the user. You want to log the exception and display some friendly error message to the user.

In such cases you can use something like this:

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Runtime.Filters;

namespace DotvvmDemo
{
    public class ErrorHandlingActionFilter : ExceptionFilterAttribute
    {
        protected override Task OnCommandExceptionAsync(IDotvvmRequestContext context, ActionInfo actionInfo, Exception exception)
        {
            // AppViewModelBase declares the ErrorMessage property to display error messages
            // If it is set, the master page will display the error message alert.
            if (context.ViewModel is AppViewModelBase)
            {
                ((AppViewModelBase) context.ViewModel).ErrorMessage = exception.Message;
                
                // We need the request to end normally, not with an error
                context.IsCommandExceptionHandled = true;
            }

            return base.OnCommandExceptionAsync(context, actionInfo, exception);
        }       
    }
}
```

The `AppViewModelBase` is a base class for all viewmodels in the application and has the `ErrorMessage` property. If the request execution should 
continue like there was no error, we need to set `context.IsCommandExceptionHandled` to `true`.


## Create a custom error page

If the exception occurs during the `Init`, `Load` and `PreRender` phase, you often need to redirect the user to an error page. 

You can do it in the `OnPageExceptionAsync` method like this:

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Runtime.Filters;

namespace DotvvmDemo
{
    public class ErrorHandlingActionFilter : ExceptionFilterAttribute
    {
        protected override Task OnPageExceptionAsync(IDotvvmRequestContext context, Exception exception)
        {
            // Suppress the default DotVVM error page
            context.IsPageExceptionHandled = true;
            
            // TODO: Log the exception details
            
            // Redirect to the /error500 page 
            context.RedirectToUrl("/error500");

            return base.OnPageExceptionAsync(context, exception);
        }       
    }
}
```

## See also

* [Filters](overview)
* [Action filters](action-filters)
* [Authentication and authorization](~/pages/concepts/security/authentication-and-authorization/overview)