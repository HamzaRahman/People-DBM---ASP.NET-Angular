class PeopleTable extends React.Component
{
    state = { data: this.props.initialData };

    loadCommentsFromServer = () => {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    };
    render()
    {
        return (
            <div>
                <div>
                     HHHHH
                </div>
                Hello, world! I am a CommentBox.
            </div>
        );
    }
}
class PeopleList extends React.Component {
    render() {
        var personNodes = this.props.data.map(function (person) {
            return (
                <Comment author={comment.author} key={comment.id}>
                    {comment.text}
                </Comment>
            );
        });
        return <div className="commentList">{commentNodes}</div>;
    }
}
function createRemarkable() {
    var remarkable =
        'undefined' != typeof global && global.Remarkable
            ? global.Remarkable
            : window.Remarkable;

    return new remarkable();
}
class Person extends React.Component {
    rawMarkup = () => {
        var md = createRemarkable();
        var rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };
    };

    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor">{this.props.author}</h2>
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
            </div>
        );
    }
}
ReactDOM.render(<PeopleTable />, document.getElementById('PersonTable'));