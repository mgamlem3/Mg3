# 🔢 Enumerable Utility

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

## AsIReadOnlyList

### Description

Extension method that will take any `IEnumerable<T>` and return it as an `IReadOnlyList`.

### Examples

{% tabs %}
{% tab title="Using List" %}
```csharp
List<int> foo = new() { 0, 1, 2 };

return foo.AsIReadOnlyList(); // (IReadOnlyList<int>) foo
```
{% endtab %}

{% tab title="Using Enumerable" %}
```csharp
Collection<int> foo = new() { 0, 1, 2 };

return foo.AsIReadOnlyList(); // (IReadOnlyList<int>) foo.ToList()
```
{% endtab %}
{% endtabs %}

## AsReadOnlyCollection

### Description

Takes any `IEnumerable` and wraps it in a `ReadOnlyCollection`

### Example

```csharp
List<int> foo = new() { 0, 1, 2 };

return foo.AsReadOnlyCollection(); // return new ReadOnlyCollection<int>(foo);
```

## WhereNotNull

{% hint style="warning" %}
The type of `IEnumerable` must be a `class`
{% endhint %}

### Description

Takes any `IEnumerable<T?>` and returns `IEnumerable<T>` without null values. This can be useful when you want to ensure no null values exist in the enumerable

### Examples

{% tabs %}
{% tab title="Null Values" %}
```csharp
List<Item?> items = { item1, null, item2 };

return items.WhereNotNull(); // { item1, item2 }
```
{% endtab %}

{% tab title="No Null Values" %}
```csharp
List<Item?> items = { item1, item2, item3 };

return items.WhereNotNull(); // { item1, item2, item3 } (no change)
```
{% endtab %}

{% tab title="Value Type" %}
{% hint style="danger" %}
Using this on a value type will cause an error!
{% endhint %}

```csharp
List<int> items = { 0, 1, 2 };

return items.WhereNotNull(); // Uh oh!
```
{% endtab %}
{% endtabs %}

## LazyWhereNotNull

{% hint style="warning" %}
The type of `IEnumerable` must be a `class`
{% endhint %}

### Description

This operates like `WhereNotNull` but uses `yield`. It takes any `IEnumerable<T?>` and returns `IEnumerable<T>` without null values. This can be useful when you want to ensure no null values exist in the enumerable

### Examples

{% tabs %}
{% tab title="Null Values" %}
```csharp
List<Item?> items = { item1, null, item2 };

return items.LazyWhereNotNull(); // { item1, item2 }
```
{% endtab %}

{% tab title="No Null Values" %}
```csharp
List<Item?> items = { item1, item2, item3 };

return items.LazyWhereNotNull(); // { item1, item2, item3 } (no change)
```
{% endtab %}

{% tab title="Value Type" %}
{% hint style="danger" %}
Using this on a value type will cause an error!
{% endhint %}

```csharp
List<int> items = { 0, 1, 2 };

return items.LazyWhereNotNull(); // Uh oh!
```
{% endtab %}
{% endtabs %}

