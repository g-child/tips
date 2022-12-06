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
