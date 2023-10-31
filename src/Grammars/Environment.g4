grammar Environment;

import Expression;

envBlock:
	'\\begin{' envName '}' envContent '\\end{' envName '}';

envName: 'cases';

envContent: tabularContent;

tabularContent: tabularRow+;

tabularRow: tabularCell+ '\\\\';

tabularCell: expr '&'?;
