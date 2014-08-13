Place the DummyVulnerability.java file in the directory of the Active Scan extension of ZAP, located at:

\zaproxy\src\org\zaproxy\zap\extension\ascan\

When ZAP is built and run, the DummyVulnerability will be a part of ZAP, and can be enabled throgut the Active Scanner settings. It will search for the string "DummyVulnerability" in the response body of any scanned HttpMessages, and raise an alert if found.