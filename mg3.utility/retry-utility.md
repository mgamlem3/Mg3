# 🔄 Retry Utility

## Summary

Collection of methods that are intended to allow operations to be retried when an exception occurs or an unexpected result is reached.

## RetryOnExceptionAsync

### Description

Method that will retry an operation if an exception is caught. If no exception is caught, the method will return the result.

### Parameters

#### `Func<Task<T>> function`

Generic function that will be executed and awaited by the method

#### `int maxRetries`

Maximum number of times `function` will be executed. Defaults to 5.

#### `int[]? backoffTimes`

Optional array of times in milliseconds that the thread will sleep between executions of the function. May be any size, but if larger than `maxRetries` the extra times will be ignored.

### Exceptions

#### ArgumentNullException

Thrown when `function` is not provided

#### RetryUtilityException

Thrown when `maxRetries` is met with the failure as the `innerException`

### Examples

{% tabs %}
{% tab title="Simple" %}
This example risks throwing an exception back to the caller and will retry a maximum of 5 times.

{% code lineNumbers="true" %}
```csharp
using Mg3.Utility.RetryUtility;
using System.Net.Http;

async Task<string> GetStringAsync()
{
    var myString = await new GetRemoteStringAsync();
    
    return !myString.IsNullOrWhitespace() ? myString : "No string";
}

async Task<string> DoThing()
{
    var result = await RetryUtility.RetryOnExceptionAsync<string>(GetStringAsync);
    
    return $"Here is my string: {result}";
}
```
{% endcode %}
{% endtab %}

{% tab title="Advanced" %}
This example configures the retry function to retry 2 times and back off 1 and 2 seconds between each retry.

{% code lineNumbers="true" %}
```csharp
using Mg3.Utility.RetryUtility;
using System.Net.Http;

async Task<string> GetStringAsync()
{
    var myString = await GetRemoteStringAsync();
    
    return !myString.IsNullOrWhitespace() ? myString : "No string";
}

async Task<string> DoThing()
{
    try
    {
        var result = await RetryUtility.RetryOnExceptionAsync<string>(GetStringAsync, 2, new int[] { 1000, 2000 });
        
        return $"Here is my string: {result}";
    }
    catch (RetryUtility.RetryUtilityException e)
    {
        if (e.InnerException is HttpRequestException)
            return "";
        else
            throw e.InnerException;
    }
}
```
{% endcode %}

Notice how the `RetryUtilityException` allows for you to catch only the failure from the final retry. This allows you to decide what to do based on the type of exception thrown.
{% endtab %}
{% endtabs %}

## RetryUtilityException

### Description

Basic exception that is thrown by the RetryUtility. It inherits from and implements `System.Exception`.

### Properties

#### `bool WasThrownFromRetry`

Set to `true` when the exception is thrown while retrying the operation requested by the user.

#### `bool WasThrownOnFinalRetry`

Set to true when the exception is the result from a failure on the final retry of the operation requested by the user.

### Tips

* Use `InnerException` to perform different operations based on the failure of your operation
* It may not be useful to allow this exception type to bubble up outside of the context where a RetryUtility function is called.
