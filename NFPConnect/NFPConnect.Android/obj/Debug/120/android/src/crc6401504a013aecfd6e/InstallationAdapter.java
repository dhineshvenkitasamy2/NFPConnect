package crc6401504a013aecfd6e;


public class InstallationAdapter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.microsoft.windowsazure.messaging.notificationhubs.InstallationAdapter
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_saveInstallation:(Lcom/microsoft/windowsazure/messaging/notificationhubs/Installation;Lcom/microsoft/windowsazure/messaging/notificationhubs/InstallationAdapter$Listener;Lcom/microsoft/windowsazure/messaging/notificationhubs/InstallationAdapter$ErrorListener;)V:GetSaveInstallation_Lcom_microsoft_windowsazure_messaging_notificationhubs_Installation_Lcom_microsoft_windowsazure_messaging_notificationhubs_InstallationAdapter_Listener_Lcom_microsoft_windowsazure_messaging_notificationhubs_InstallationAdapter_ErrorListener_Handler:WindowsAzure.Messaging.NotificationHubs.IInstallationAdapterInvoker, Xamarin.Azure.NotificationHubs.Android\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Azure.NotificationHubs.Client.InstallationAdapter, Microsoft.Azure.NotificationHubs.Client", InstallationAdapter.class, __md_methods);
	}


	public InstallationAdapter ()
	{
		super ();
		if (getClass () == InstallationAdapter.class) {
			mono.android.TypeManager.Activate ("Microsoft.Azure.NotificationHubs.Client.InstallationAdapter, Microsoft.Azure.NotificationHubs.Client", "", this, new java.lang.Object[] {  });
		}
	}


	public void saveInstallation (com.microsoft.windowsazure.messaging.notificationhubs.Installation p0, com.microsoft.windowsazure.messaging.notificationhubs.InstallationAdapter.Listener p1, com.microsoft.windowsazure.messaging.notificationhubs.InstallationAdapter.ErrorListener p2)
	{
		n_saveInstallation (p0, p1, p2);
	}

	private native void n_saveInstallation (com.microsoft.windowsazure.messaging.notificationhubs.Installation p0, com.microsoft.windowsazure.messaging.notificationhubs.InstallationAdapter.Listener p1, com.microsoft.windowsazure.messaging.notificationhubs.InstallationAdapter.ErrorListener p2);

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
