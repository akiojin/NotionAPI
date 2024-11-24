#!/bin/bash

if [ "$#" -ne 1 ]; then
    echo "Usage: ./publish.sh <major/minor/patch>"
    exit 1
fi

BRANCH=$(git rev-parse --abbrev-ref HEAD)

if [ "$BRANCH" != "develop" ]; then
    echo "Error: You must be on the develop branch to publish."
    exit 1
fi

PACKAGE_NAME="$(basename $(pwd))"
CSPROJ=$PACKAGE_NAME/$PACKAGE_NAME.csproj

VERSION=$(npm version $1 --no-git-tag-version | sed -e "s/v//g")

sed -i -e "s/<VersionPrefix>.*<\/VersionPrefix>/<VersionPrefix>$VERSION<\/VersionPrefix>/g" $CSPROJ
rm -rf $CSPROJ-e

git pull
git add package.json $CSPROJ
git commit -m "bump: v$VERSION"
git push

gh pr create --base main --head develop --title "bump: v$VERSION" --body "bump: v$VERSION"
