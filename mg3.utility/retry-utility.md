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
