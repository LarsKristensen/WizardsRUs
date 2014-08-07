WizardsRUs
==========

An Asp.Net MVC solution for Visual Studio 2012, used for testing web-wizards with different properties. 

It is used to test the Sequence mechanism for ZAP, found here:
https://github.com/LarsKristensen/SequenceZAP

On any of the wizards, type "dummy" (case insensitive) in the first textbox, and on the third step, an extra checkbox and a a string containing "DummyVulnerability" will be present. We then created an active scan rule for ZAP, which would search for the DummyVulnerability-string, and raise an alert if found. That way, we would know if the Sequence mechanism actually would work.

For the wizard requiring authentication, you can use the credentials [user1:pw1] or [user2:pw2], or you can add new ones, in the dictionary of the HomeControler.

Read more about the Sequence mechanism, how it works and how it was implemented, on our development blog:
http://zapmultistep.wordpress.com/ 
