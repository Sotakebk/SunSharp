#!/bin/bash
set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DOCFX_CMD="docfx"

get_project_dir() {
    local dir="$SCRIPT_DIR"
    while [ ! -d "$dir/.git" ] && [ "$dir" != "/" ]; do
        dir="$(dirname "$dir")"
    done
    if [ "$dir" == "/" ]; then
        echo "Error: Could not find the root directory of the repository." >&2
        exit 1
    fi
    echo "$dir"
}

PROJECT_DIR="$(get_project_dir)"

check_dotnet() {
    if ! command -v dotnet &> /dev/null; then
        echo ".NET SDK is not installed." >&2
        exit 1
    fi

    DOTNET_VERSION="$(dotnet --version)"
    echo "Using .NET SDK version $DOTNET_VERSION"
}

install_docfx() {
    if dotnet tool list -g | grep -q "docfx"; then
        :
    else
        echo "Installing DocFX"
        dotnet tool install -g docfx
    fi

    VERSION="$($DOCFX_CMD --version)"
    
    echo "Using DocFX $VERSION"
}

clean() {
    echo "Cleaning generated documentation files"
    rm -rf "$PROJECT_DIR/docs/out"
}

serve() {
    echo "Serving documentation with hot-reload"
    echo "Press Ctrl+C to stop"
    $DOCFX_CMD "$PROJECT_DIR/docs/docfx.json" --serve
}

main() {
    check_dotnet
    install_docfx
    clean
    serve
}

main "$@"
