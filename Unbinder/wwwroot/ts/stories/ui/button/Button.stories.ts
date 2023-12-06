import type { Meta, StoryObj } from "@storybook/html";
import { ButtonProps, createButton } from "./Button";

type StrongMetaType<T> =
    Omit<Meta<T>, 'title'> & { title: string } |
    Omit<Meta<T>, 'component'> & { component: NonNullable<any> }

const meta: StrongMetaType<ButtonProps> = {
    title: "Button",
    tags: ['general-ui'],
    render: (args) => createButton(args),
    argTypes: {
        label: { control: 'text' },
        onClick: { action: 'onClick' },
        primary: { control: 'boolean' },
        "asp-action": { control: 'text' },
        "asp-controller": { control: 'text' }
    }
};

export default meta;
type Story = StoryObj<ButtonProps>;

export const Primary: Story = {
    args: {}
}
