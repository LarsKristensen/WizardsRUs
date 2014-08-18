Place the DummyVulnerability.java file in the directory of the Active Scan extension of ZAP, located at:

\zaproxy\src\org\zaproxy\zap\extension\ascan\

When ZAP is built and run, the DummyVulnerability will be a part of ZAP, and can be enabled throgut the Active Scanner settings. It will search for the string "DummyVulnerability" in the response body of any scanned HttpMessages, and raise an alert if found.

The three scripts will run through each respective wizard, and attempt to expose the Dummy Vulnerability, by posting a string containing "dummy" on step1.

All three scripts will attempt to access "wizardsrus.dk", so once the application is deployed to localhost, the HOSTS file was edited, to redirect any requests to wizardsrus.dk to localhost, by adding the line:

127.0.0.1 wizardsrus.dk