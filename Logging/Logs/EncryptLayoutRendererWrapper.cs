//using System.ComponentModel;
//using Dyneval.InstrumentControl.PlatformCommon.Setting;
//using NLog.Config;
//using NLog.LayoutRenderers;
//using NLog.LayoutRenderers.Wrappers;

//namespace Dyneval.InstrumentControl.PlatformCommon.Logs;

//[LayoutRenderer("Encrypt")]
//[AmbientProperty("Encrypt")]
//[ThreadAgnostic]
//public sealed class EncryptLayoutRendererWrapper : WrapperLayoutRendererBase
//{
//    /// This stores the private key in plain text in code - this does not provide security, but obscurity.
//    /// Without being able to refer to custom hardware or a third party service (i.e. the internet), this is
//    /// the best we can do on a single client machine. The code as a whole should be obfuscated to support this.
//    private const string PrivateKey = "r0C6oScuiKINQQJDTn1amYZ77xtyfoqP";

//    public EncryptLayoutRendererWrapper()
//    {
//        Encrypt = true;
//    }

//    [DefaultValue(value: true)] public bool Encrypt { get; set; }

//    protected override string Transform(string text)
//    {
//        string encryptedMessage = EncryptionHelper.Encrypt(text, PrivateKey);

//        return encryptedMessage;
//    }
//}
