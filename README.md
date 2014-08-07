WizardsRUs
==========

An Asp.Net MVC solution, used for testing different web-wizards. 

It is used to test the Sequence mechanism for ZAP, found here:
https://github.com/LarsKristensen/SequenceZAP

On any of the wizards, type "dummy" (case insensitive) in the first textbox, and on the third step, an extra checkbox and a a string containing "DummyVulnerability" will be present. We then created an active scan rule for ZAP, which would search for the DummyVulnerability-string, and raise an alert if found. That way, we would know if the Sequence mechanism actually would work.

Read more about the Sequence mechanism, how it works and how it was implemented, on our development blog:
http://zapmultistep.wordpress.com/ 
