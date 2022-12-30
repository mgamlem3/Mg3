# JsonUtility

## Summary

Many aspects of this utility interact with [Newtonsoft's Json.NET](https://www.newtonsoft.com/json)

## Namespace

`Mg3.Json.JsonUtility`

## DefaultContractResolver

{% hint style="info" %}
Uses the Newtonsoft.Json
{% endhint %}

Sets the `DefaultNamingStrategy` to `SnakeCaseNamingStrategy`

## JsonSerializerSettings

{% hint style="info" %}
Uses Newtonsoft.Json
{% endhint %}

Uses the above `DefaultContractResolver`

Sets the `NullValueHandling` to `NullValueHandling.Ignore`
