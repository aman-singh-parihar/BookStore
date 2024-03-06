- To display all the validation errors.
```
asp-validation-summary = ALL
```

- To display only custom model errors which are setup in the code.
```
asp-validation-summary = ModelOnly

ex:- ModelState.AddModelError("name", "Category Name and Display Order should not be same");
```