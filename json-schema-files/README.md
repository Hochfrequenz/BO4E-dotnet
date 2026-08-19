## JSchema files for BO4E Business Objects

These files are automatically generated from the C# classes whenever a release is published: the
[Generate Schemas and TypeScript Models](/.github/workflows/generate_schemas_and_ts_models.yml)
workflow runs the generator and opens a Pull Request with the result.

To regenerate them manually, run [`SchemaGenerator/generate-json-schemas.sh`](/SchemaGenerator/generate-json-schemas.sh)
(or the `.ps1` next to it) from anywhere in the repository.

The schemas are also converted into the TypeScript interfaces of
[bo4e-dotnet-ts-models](https://github.com/Hochfrequenz/bo4e-dotnet-ts-models) by the same workflow.

Note that the `BO4E.BO.*.json` files are outdated leftovers of an older naming scheme. They are no
longer generated, but they are still the schemas the npm package exports its types from, so they
cannot be removed without a breaking change to that package.
