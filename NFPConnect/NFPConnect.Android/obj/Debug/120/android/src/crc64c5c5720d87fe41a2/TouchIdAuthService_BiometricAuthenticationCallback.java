package crc64c5c5720d87fe41a2;


public class TouchIdAuthService_BiometricAuthenticationCallback
	extends android.hardware.biometrics.BiometricPrompt.AuthenticationCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAuthenticationSucceeded:(Landroid/hardware/biometrics/BiometricPrompt$AuthenticationResult;)V:GetOnAuthenticationSucceeded_Landroid_hardware_biometrics_BiometricPrompt_AuthenticationResult_Handler\n" +
			"n_onAuthenticationFailed:()V:GetOnAuthenticationFailedHandler\n" +
			"n_onAuthenticationHelp:(ILjava/lang/CharSequence;)V:GetOnAuthenticationHelp_ILjava_lang_CharSequence_Handler\n" +
			"";
		mono.android.Runtime.register ("NFPConnect.Droid.Services.TouchIdAuthService+BiometricAuthenticationCallback, NFPConnect.Android", TouchIdAuthService_BiometricAuthenticationCallback.class, __md_methods);
	}


	public TouchIdAuthService_BiometricAuthenticationCallback ()
	{
		super ();
		if (getClass () == TouchIdAuthService_BiometricAuthenticationCallback.class) {
			mono.android.TypeManager.Activate ("NFPConnect.Droid.Services.TouchIdAuthService+BiometricAuthenticationCallback, NFPConnect.Android", "", this, new java.lang.Object[] {  });
		}
	}


	public void onAuthenticationSucceeded (android.hardware.biometrics.BiometricPrompt.AuthenticationResult p0)
	{
		n_onAuthenticationSucceeded (p0);
	}

	private native void n_onAuthenticationSucceeded (android.hardware.biometrics.BiometricPrompt.AuthenticationResult p0);


	public void onAuthenticationFailed ()
	{
		n_onAuthenticationFailed ();
	}

	private native void n_onAuthenticationFailed ();


	public void onAuthenticationHelp (int p0, java.lang.CharSequence p1)
	{
		n_onAuthenticationHelp (p0, p1);
	}

	private native void n_onAuthenticationHelp (int p0, java.lang.CharSequence p1);

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
