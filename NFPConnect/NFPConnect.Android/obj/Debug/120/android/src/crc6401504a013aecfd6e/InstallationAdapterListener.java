package crc6401504a013aecfd6e;


public class InstallationAdapterListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.microsoft.windowsazure.messaging.notificationhubs.InstallationAdapter.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInstallationSaved:(Lcom/microsoft/windowsazure/messaging/notificationhubs/Installation;)V:GetOnInstallationSaved_Lcom_microsoft_windowsazure_messaging_notificationhubs_Installation_Handler:WindowsAzure.Messaging.NotificationHubs.IInstallationAdapterListenerInvoker, Xamarin.Azure.NotificationHubs.Android\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Azure.NotificationHubs.Client.InstallationAdapterListener, Microsoft.Azure.NotificationHubs.Client", InstallationAdapterListener.class, __md_methods);
	}


	public InstallationAdapterListener ()
	{
		super ();
		if (getClass () == InstallationAdapterListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Azure.NotificationHubs.Client.InstallationAdapterListener, Microsoft.Azure.NotificationHubs.Client", "", this, new java.lang.Object[] {  });
		}
	}


	public void onInstallationSaved (com.microsoft.windowsazure.messaging.notificationhubs.Installation p0)
	{
		n_onInstallationSaved (p0);
	}

	private native void n_onInstallationSaved (com.microsoft.windowsazure.messaging.notificationhubs.Installation p0);

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
