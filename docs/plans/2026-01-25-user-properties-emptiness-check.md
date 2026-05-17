# User Properties Emptiness Check - Implementation Plan

## Overview

Add utility methods to check if `UserProperties` (JSON extension data) are empty for objects implementing `IUserProperties`. This indicates whether all JSON fields could be mapped to model properties.

## Requirements

1. **Simple check**: Method to check if `UserProperties` is empty for a single object
2. **Recursive check**: Method that recursively checks all nested `IUserProperties` objects, returning:
   - Boolean: true if ALL UserProperties are empty (object and nested)
   - Paths: List of paths pointing to objects with non-empty UserProperties

## Design Decisions

- **Cached reflection**: Use `ConcurrentDictionary<Type, PropertyInfo[]>` to cache property metadata per type
- **Public properties only**: Only check public instance properties
- **Collection support**: Handle `List<T>`, arrays, and other `IEnumerable<T>` containing `IUserProperties`
- **Thread-safe**: All caching uses concurrent collections
- **Circular reference protection**: Track visited objects to prevent infinite loops

## Implementation Steps

### Step 1: Add extension methods to UserPropertiesExtensions.cs

Location: `BO4E/UserPropertiesExtensions.cs`

Add:
```csharp
// Simple check - returns true if UserProperties is null or empty
public static bool HasEmptyUserProperties<TParent>(this TParent parent)
    where TParent : IUserProperties

// Recursive check - returns true if all nested UserProperties are empty
public static bool HasAllEmptyUserPropertiesRecursive<TParent>(
    this TParent parent,
    out IReadOnlyList<string> nonEmptyPaths)
    where TParent : IUserProperties
```

Internal helper methods:
- `GetPropertiesToCheck(Type type)` - cached reflection lookup
- `IsUserPropertiesType(Type type)` - check if type implements IUserProperties
- `GetEnumerableElementType(Type type)` - get element type if IEnumerable<IUserProperties>
- `CheckRecursive(...)` - internal recursive implementation with visited tracking

### Step 2: Add comprehensive tests

Location: `BO4ETestProject/TestUserPropertiesEmptiness.cs`

Test cases:
1. **Null handling**: null object returns true (nothing to check)
2. **Empty UserProperties**: null dictionary, empty dictionary
3. **Non-empty UserProperties**: dictionary with entries
4. **Single nested property**: IUserProperties property (null, empty, non-empty)
5. **List properties**: List<IUserProperties> with various states
6. **Array properties**: IUserProperties[] with various states
7. **Deep nesting**: 3+ levels of nested IUserProperties
8. **Mixed scenarios**: some empty, some not at different levels
9. **Path correctness**: verify path format "Property[0].SubProperty"
10. **Real BO4E objects**: Energiemenge with Verbrauch list
11. **Thread safety**: concurrent access doesn't cause issues
12. **Performance**: cached reflection is actually faster on repeated calls

### Step 3: Code review

- Review by JSON/serialization expert for any edge cases with Newtonsoft.Json and System.Text.Json
- Implement any findings

### Step 4: Final steps

- Run csharpier formatting
- Run all tests
- Push and create PR

## API Examples

```csharp
// Simple check
var melo = new Messlokation { ... };
bool isEmpty = melo.HasEmptyUserProperties(); // true if UserProperties is null or Count == 0

// Recursive check
var energiemenge = new Energiemenge
{
    Energieverbrauch = new List<Verbrauch> { ... }
};
bool allEmpty = energiemenge.HasAllEmptyUserPropertiesRecursive(out var paths);
// If false, paths might contain: ["Energieverbrauch[0]", "Energieverbrauch[2]"]
```

## Files to Create/Modify

1. **Modify**: `BO4E/UserPropertiesExtensions.cs` - add new methods
2. **Create**: `BO4ETestProject/TestUserPropertiesEmptiness.cs` - comprehensive tests
