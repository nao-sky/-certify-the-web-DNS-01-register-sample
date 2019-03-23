# -certify-the-web-DNS-01-register-sample

iis で　certify the web (lets encrypt client) 使う （MyDns.jp の場合）


とりあえず、非公式の方法なことを承知いただきたい

今現在試したのは、ワイルドカード証明書の DNS-01 による取得

certify the web クライアントの使い方はあちこちにあると思うので割愛。

問題は、MyDns.jp のTXTレコードの regist delete の処理だけだったので、
PowerShell 書けなかったためちょっと C# でコード書いて実行ファイルにした。

というわけで以下
https://github.com/nao-sky/-certify-the-web-DNS-01-register-sample
の BIN ディレクトリから全部のファイルを任意のフォルダに保存。
config ファイルを設定

あとは certify the web の
authorization
　create script path に、先に保存した LetsMyDNSjpRegist.exe をフルパスで入力
　delete script path に、同様に保存した LetsMyDNSjpDelete.exe をフルパスで入力

以上で、regist delete のスクリプト替わりが出来たので、あとは test & execute

実行ファイルを .net core 3 preview で作ってしまったので動かなかったらごめんなさい。

難しいことはしてないので、最悪ソースをコピーして使ってみてください。

誰かの役に立てば幸いです。
