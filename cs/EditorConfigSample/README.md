# EditorConfigSample


## 確認したいこと1. 

EditorConfig に file-scoped namespace の設定を入れたら新規にクラスを追加しても file-scoped になっているかを確認する

### 試したこと

#### editorconfig の追加

フォルダに `.editorconfig` のファイルを追加して

`csharp_style_namespace_declarations = file_scoped:silent`

と書いた

#### 適当な新規ソリューションとプロジェクトを追加してnamespace が file-scoped になっていることを確認

ASP.NET Core Web API (.NET 7) を適当に .editorconfig を置いたところと同じフォルダに作ったところ、namespace がちゃんと file-scoped になっていた

「Add New Item」でクラスを新規に追加してもちゃんと file-scoped になっていた。問題なし。

## 確認したいこと2.

個人的に、private readonly のフィールドは _ 始まりだと気持ちが良いので、そのようなルールを定義できないかと考えた。

コードスタイルの名前付けルール: 例: アンダースコアが含まれるプライベート インスタンス フィールド
https://learn.microsoft.com/ja-jp/dotnet/fundamentals/code-analysis/style-rules/naming-rules#example-private-instance-fields-with-underscore

上記ドキュメントを見つけたので、これでうまくいくかを確認する。

ほぼ同一でよいと思いましたが、そのまま適用すると、`_Logger` のように Pascal Case のルールになってしまうようだったので、そこだけ直した。以下のような定義を書いて、概ね希望通りの動きになったように感じた。LGTM。

```
# Naming rules
dotnet_naming_style.underscored.capitalization = camel_case
dotnet_naming_style.underscored.required_prefix = _
dotnet_naming_rule.private_fields_underscored.symbols = private_fields
dotnet_naming_rule.private_fields_underscored.style = underscored
dotnet_naming_rule.private_fields_underscored.severity = error
dotnet_naming_rule.private_static_fields_none.symbols = private_static_fields
dotnet_naming_rule.private_static_fields_none.style = underscored
dotnet_naming_rule.private_static_fields_none.severity = none

# Symbol specifications
dotnet_naming_symbols.private_fields.applicable_kinds = field
dotnet_naming_symbols.private_fields.applicable_accessibilities = private
dotnet_naming_symbols.private_static_fields.applicable_kinds = field
dotnet_naming_symbols.private_static_fields.applicable_accessibilities = private
dotnet_naming_symbols.private_static_fields.required_modifiers = static
```