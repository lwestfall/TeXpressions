# Contributing

When contributing to this repository, please first discuss the change you wish to make via issue,
email, or any other method with the owners of this repository before making a change.

Please note we have a [code of conduct](CODE_OF_CONDUCT.md), please follow it in all your interactions with the project.

## Getting Started

If you are new to .NET development, welcome! This repo is beginner friendly, don't be afraid to ask
questions in the [discussions](https://github.com/lwestfall/TeXpressions/discussions)! Questions don't
have to be related to this project per-se. I'm happy to help with any general .NET or Git questions.

Here's a few notes for those who are just getting started:

1. [Download and install the .NET SDK](https://dotnet.microsoft.com/en-us/download). At time of writing, this library targets .NET 6. That means you'll need to download the SDK for .NET 6 **or later** (the SDKs are backward compatible).
2. If you don't have Git installed on your computer, [follow the instructions for your OS here](https://github.com/git-guides/install-git).
3. Clone this repository:
   - If you like the command-line: `git clone https://github.com/lwestfall/TeXpressions.git`
   - If you like Github desktop or another GUI, clone from URL: <https://github.com/lwestfall/TeXpressions.git>

## Recommendations

You are of course free to use whatever IDE you prefer, but I strongly recommend using something
with support (either natively or via extension/plugin) for .editorconfig files, and consider
turning on "Format on save" or similar. This repo has automated format checking and PRs *will* be
rejected if the formatting doesn't meet specifications.

## Pull Request Process

1. Ensure any install or build dependencies are removed before the end of the layer when doing a
   build.
2. Update the README.md with details of changes to the interface, this includes new environment
   variables, exposed ports, useful file locations and container parameters.
3. One of the repository owners will merge your pull request following a review and passing of
   all checks.
