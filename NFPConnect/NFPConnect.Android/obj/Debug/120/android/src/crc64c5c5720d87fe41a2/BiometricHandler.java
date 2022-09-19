package crc64c5c5720d87fe41a2;


public class BiometricHandler
	extends androidx.core.hardware.fingerprint.FingerprintManagerCompat.AuthenticationCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAuthenticationFailed:()V:GetOnAuthenticationFailedHandler\n" +
			"n_onAuthenticationSucceeded:(Landroidx/core/hardware/fingerprint/FingerprintManagerCompat$AuthenticationResult;)V:GetOnAuthenticationSucceeded_Landroidx_core_hardware_fingerprint_FingerprintManagerCompat_AuthenticationResult_Handler\n" +
			"";
		mono.android.Runtime.register ("NFPConnect.Droid.Services.BiometricHandler, NFPConnect.Android", BiometricHandler.class, __md_methods);
	}


	public BiometricHandler ()
	{
		super ();
		if (getClass () == BiometricHandler.class) {
			mono.android.TypeManager.Activate ("NFPConnect.Droid.Services.BiometricHandler, NFPConnect.Android", "", this, new java.lang.Object[] {  });
		}
	}

	public BiometricHandler (android.content.Context p0)
	{
		super ();
		if (getClass () == BiometricHandler.class) {
			mono.android.TypeManager.Activate ("NFPConnect.Droid.Services.BiometricHandler, NFPConnect.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public void onAuthenticationFailed ()
	{
		n_onAuthenticationFailed ();
	}

	private native void n_onAuthenticationFailed ();


	public void onAuthenticationSucceeded (androidx.core.hardware.fingerprint.FingerprintManagerCompat.AuthenticationResult p0)
	{
		n_onAuthenticationSucceeded (p0);
	}

	private native void n_onAuthenticationSucceeded (androidx.core.hardware.fingerprint.FingerprintManagerCompat.AuthenticationResult p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
