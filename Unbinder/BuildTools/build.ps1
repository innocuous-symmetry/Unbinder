function RebuildJS {
    echo "Rebuilding JS..."

    # check for node modules
    if (!(Test-Path ./node_modules)) {
	    echo "Installing node modules..."
	    npm install
    }

    # delete old JS files if they exist
    if (Test-Path ./wwwroot/js) {
        echo "Removing old build files..."
        ri -r -fo ./wwwroot/js
    }

    echo "Compiling..."
    npx tsc

    echo "Adjusting import statements..."

    # find import statements based on regex and append ".js" file ending to each
    $regex = "import\s+.*\s+from\s+['""](.*)['""]"

    $files = Get-ChildItem -Path ./wwwroot/js -Recurse -Include *.js -File
    $adjustedFiles = 0

    foreach ($file in $files) {
		$content = Get-Content $file.FullName
		$importMatches = $content | Select-String -Pattern $regex -AllMatches

        $adjustedFiles += $importMatches.Matches.Count

		foreach ($match in $importMatches.Matches) {
			$import = $match.Groups[1].Value
			$newImport = $import + ".js"
			$content = $content -replace $import, $newImport
		}

		$content | Set-Content $file.FullName
	}

    echo "Adjusted $adjustedFiles import statements."
}

function BuildStorybook {
	echo "Building Storybook..."
	npm run build-storybook
}


# option for only compiling JS
if ($args[0] -eq "-js") {
    RebuildJS
    echo "Done."
# run full build
} else {
    RebuildJS
    BuildStorybook
    # to do: include Docker?
    echo "Done."
}
