
namespace DanceSchoolAPI.Models.Options;

public class HostingOptions : IOptions
{
    public string SectionKey => "Hosting";

    public short InsecurePort { get; set; }

    public short SecurePort { get; set; }

    public bool UseSwagger { get; set; }

    public string CertificatePath { get; set; }

    public string CertificatePassword { get; set; }

    public bool UseInsecure => InsecurePort != 0;

    public bool UseSecure => SecurePort != 0 && !string.IsNullOrEmpty(CertificatePath);
}
