# Enumerable Utility

## Summary

Extension methods that are meant to operate on any object that implements `Enumerable` or inherits from `IEnumerable`

## IsNullOrEmpty

### Description

Extension method that checks if the `IEnumerable` is `null` or contains 0 values

### Examples

{% tabs %}
{% tab title="With Values" %}
```csharp
List<int> foo = new() { 0, 1, 2 };

foo.IsNullOrEmpty(); // false
```
{% endtab %}

{% tab title="Empty" %}
```csharp
List<int> foo = new() { };

foo.IsNullOrEmpty(); // true
```
{% endtab %}

{% tab title="Null" %}
```csharp
List<int>? foo = null;

foo.IsNullOrEmpty(); // true
```
{% endtab %}
{% endtabs %}

## EmptyIfNull

### Description

Extension method that returns an empty `Collection<T>` if the `IEnumerable` is null. If the source is not null, no modification is made and the source is returned. If the source is null, an empty collection of the source type is returned.

This can be helpful when you want to ensure you are not passing a `null` value back from a function.

### Examples

{% tabs %}
{% tab title="Not Null" %}
```csharp
List<int> foo = new() { 0, 1, 2 };

return foo.EmptyIfNull(); // { 0, 1, 2 }
```
{% endtab %}

{% tab title="Null" %}
```csharp
List<int> foo = null;

return foo.EmptyIfNull(); // new Collection<int>()
```
{% endtab %}
{% endtabs %}
