package crc6401504a013aecfd6e;


public class InstallationEnrichmentVisitor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.microsoft.windowsazure.messaging.notificationhubs.InstallationVisitor
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_visitInstallation:(Lcom/microsoft/windowsazure/messaging/notificationhubs/Installation;)V:GetVisitInstallation_Lcom_microsoft_windowsazure_messaging_notificationhubs_Installation_Handler:WindowsAzure.Messaging.NotificationHubs.IInstallationVisitorInvoker, Xamarin.Azure.NotificationHubs.Android\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Azure.NotificationHubs.Client.InstallationEnrichmentVisitor, Microsoft.Azure.NotificationHubs.Client", InstallationEnrichmentVisitor.class, __md_methods);
	}


	public InstallationEnrichmentVisitor ()
	{
		super ();
		if (getClass () == InstallationEnrichmentVisitor.class) {
			mono.android.TypeManager.Activate ("Microsoft.Azure.NotificationHubs.Client.InstallationEnrichmentVisitor, Microsoft.Azure.NotificationHubs.Client", "", this, new java.lang.Object[] {  });
		}
	}


	public void visitInstallation (com.microsoft.windowsazure.messaging.notificationhubs.Installation p0)
	{
		n_visitInstallation (p0);
	}

	private native void n_visitInstallation (com.microsoft.windowsazure.messaging.notificationhubs.Installation p0);

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
