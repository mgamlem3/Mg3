# ✍ String Utility

## Summary

Extension methods that are used to check if a string conforms to a pattern or modify the string to fit a pattern.

## IsNullOrEmpty

### Description

Implements [string.IsNullOrEmpty](https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorempty?view=net-7.0) as an extension method

### Example

```csharp
string s = "hello world";

return string.IsNullOrEmpty(s) == s.IsNullOrEmpty(); // true
```

## IsNullOrWhitespace

### Description

Implements [string.IsNullOrWhitespace](https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-7.0) as an extension method

### Example

```csharp
string s = "hello world";

return string.IsNullOrWhitespace(s) == s.IsNullOrWhitespace(); // true
```

## ContainsWhitespace

### Description

Checks to see if there are any whitespace characters in the string using `char.IsWhitespace()`

### Examples

{% tabs %}
{% tab title="Whitespace" %}
```csharp
string s = "hello world";

return s.ContainsWhitespace(); // true
```
{% endtab %}

{% tab title="No Whitespace" %}
```csharp
string s = "helloworld";

return s.ContainsWhitespace(); // false
```
{% endtab %}
{% endtabs %}

## ContainsCharacterFromCollection

### Description

Checks to see if any character from the collection is in the source string

### Example

```csharp
string s = "hello world";
var characters = new List<char>() { 'w', 'o', 'r', 'l', 'd' };

return s.ContainsCharacterFromCollection(characters.AsReadOnly()); // true
```

## ContainsOnlyCharactersFromCollection

### Description

Checks to see if only characters from the collection are in the source string

### Examples

{% tabs %}
{% tab title="True" %}
```csharp
string s = "hello";
var characters = new List<char>() { 'h', 'e', 'l', 'o' };

return s.ContainsOnlyCharactersFromCollection(characters.AsReadOnly()); // true
```
{% endtab %}

{% tab title="False" %}
```csharp
string s = "hello world";
var characters = new List<char>() { 'h', 'e', 'l', 'o' };

return s.ContainsOnlyCharactersFromCollection(characters.AsReadOnly()); // false
```
{% endtab %}
{% endtabs %}

## ContainsUpperCase

### Description

Checks to see if any character in the source string is uppercase

### Examples

{% tabs %}
{% tab title="Uppercase" %}
```csharp
string s = "Hello world";
string s1 = "Hello World";

return s.ContainsUpperCase(); // true
return s1.ContainsUpperCase(); // true
```
{% endtab %}

{% tab title="No Uppercase" %}
```csharp
string s = "hello world";

return s.ContainsUpperCase(); // false
```
{% endtab %}
{% endtabs %}

## ContainsLowerCase

### Description

Checks to see if any character in the source string is lowercase

### Examples

{% tabs %}
{% tab title="Lowercase" %}
```csharp
string s = "hello world";
string s1 = "Hello World"

return s.ContainsLowerCase(); // true
return s1.ContainsLowerCase(); // true
```
{% endtab %}

{% tab title="Second Tab" %}
```csharp
string s = "HELLO WORLD";

return s.ContainsLowerCase(); // false
```
{% endtab %}
{% endtabs %}

## ContainsMixedCase

### Description

Checks to see that the source string contains both uppercase and lowercase characters

### Examples

{% tabs %}
{% tab title="Lowercase" %}
```csharp
string s = "hello world";

return s.ContainsMixedCase(); // false
```
{% endtab %}

{% tab title="Uppercase" %}
```csharp
string s = "HELLO WORLD";

return s.ContainsMixedCase(); // false
```
{% endtab %}

{% tab title="Both" %}
```csharp
string s = "Hello World";

return s.ContainsMixedCase(); // true
```
{% endtab %}
{% endtabs %}

## ToSnakeCase

### Description

This takes any string and will convert it to snake case breaking on `_`,  , and uppercase letters

### Examples

```
"hello" -> "hello"
"helloWorld" -> "hello_world"
"HelloWorld" -> "hello_world"
"hello_world" -> "hello_world"
"hello__world" -> "hello_world"
"hello_world_" -> "hello_world"
"_hello_world" -> "hello_world"
"_hello_world_" -> "hello_world"
"_hello__world" -> "hello_world"
"hello  world" -> "hello_world"
"hello world" -> "hello_world"
"hello_ world" -> "hello_world"
"hello _world" -> "hello_world"
"hello World" -> "hello_world"
"" -> ""
```
