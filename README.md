# markdown-include

A very simple application adding the ability to include other markdown files in a markdown file.

This could have easily been something like a Python script, but I used this opportunity to fiddle around with dotnet publish.

## Usage

In a markdown file, have

```md
![include](path/to/other/markdown)
```

then run the program like this

```
mdinclude input.md output.md
```

input.md should be a markdown file containing the include directive, output.md will then be generated.

## Build

The app is based on .NET Core, feel free to build it yourself to suit your needs.
